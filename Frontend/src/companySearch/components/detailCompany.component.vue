<script>
import { HttpCommonService } from "@/services/http-common.service.js";
export default {
  name: 'companyDetail',
  data() {
    return {
      id: null,
      companyData: null,
      reviews: [],
      averageRating: null,
      reviewFilter: 'all',
      cardNumber: null,
      cvvCard:null,
      dateCard: null,
      loadQuantity: null,
      reservation:{
        services: null,
        bookingDate: null,
        pickupAddress: null,
        destinationAddress: null,
        movingDate: null,
        movingTime: null,
        weight: null
      },
      cargaSinEstres_service: null,
      ReviewService: null,
      errorMessage: '',
      userId: '',
      userType: '',
    };
  },
  created() {
    const companyData = this.$route.query.companyData;

    this.userId = this.$route.params.id;

    const routeParts = this.$route.path.split('/');
    this.userType = routeParts[1];



    if (companyData) {
      this.company = JSON.parse(companyData);
    }

    this.fetchReviews();


  },
  methods:{

    submitForm(){
      this.errorMessage = '';
      let warnings = '';

      if (!this.reservation.bookingDate || !/^\d{4}-\d{2}-\d{2}$/.test(this.reservation.bookingDate)) {
        warnings += 'La fecha de hoy debe tener el formato YYYY-MM-DD.<br>';
      }

      if (!this.reservation.services.trim().length > 4) {
        warnings += 'El campo de servicios debe contener más de 4 letras.<br>';
      }

      if (!this.reservation.pickupAddress) {
        warnings += 'El campo de dirección de entrega es requerido<br>';
      }

      if (!this.reservation.destinationAddress) {
        warnings += 'El campo de dirección de destino es requerido<br>';
      }

      if (!this.reservation.movingDate || !/^\d{4}-\d{2}-\d{2}$/.test(this.reservation.movingDate)) {
        warnings += 'La fecha de movimiento debe tener el formato YYYY-MM-DD.<br>';
      }

      if (!this.reservation.movingTime || !/^\d{2}:\d{2}$/.test(this.reservation.movingTime)) {
        warnings += 'La hora de movimiento debe tener el formato HH:MM.<br>';
      }

      if (this.reservation.weight < 0){
        warnings += 'El peso debe ser positivo';
      }

      if (this.cardNumber.length < 16) {
        warnings += 'Número de tarjeta no válido, debe tener 16 dígitos <br>';
      }
      if (this.cvvCard.length < 3) {
        warnings += 'El cvv debe tener 3 dígitos <br>';
      }

      if (!this.dateCard.length || !/^\d{2}\/\d{2}$/.test(this.dateCard)) {
        warnings += 'La fecha de cvv debe tener el formato DD-MM.<br>';
      }


      if (warnings) {
        this.errorMessage = warnings;
      } else {
        this.addReservation();
      }
    },

    addReservation() {
      this.cargaSinEstres_service = new HttpCommonService();
      this.cargaSinEstres_service.createReservation(this.userId, this.company.id ,this.reservation)
          .then((response) => {
            this.$data.reservation = response.data;

            if(this.userType ==='company'){
              this.$router.push({
                path: `/company/${this.userId}/company-booking-history`,
                name:'company-booking-history',
              });
            }
            else{
              this.$router.push({
                path: `/client/${this.userId}/client-booking-history`,
                name:'client-booking-history',
              });
            }
          });
    },

    async fetchReviews() {
      this.ReviewService = new HttpCommonService();
      this.ReviewService.getById(this.company.id)
          .then((response) => {
            const responseData = response.data;

            this.company.reviews = response.data.reviews;
            let TotalRating  = 0;
            this.company.reviews.forEach((review)=>{
              TotalRating += review.rating;
            });
            this.company.averageRating = TotalRating/this.company.reviews.length;
          });
    },
  }
};
</script>

<template>
  <div><h1 class="title flex justify-content-center">Información de empresa</h1></div>

  <!-- INFORMACION DE LA EMPRESA -->
  <pv-card class="custom-card">
    <template #title>
      <img :src="company.photo" alt="logo de empresa" class="company-logo">
    </template>

    <template #content>
      <div class="company-info">
        <h2 class="company-name">{{ company.name }}</h2>
        <p class="company-type">Empresa</p>
      </div>

      <div class="company-services">
        <p class="label">Descripción: </p>
        <p class="value">{{ company.description }}</p>
      </div>

      <div class="company-services">
        <p class="label">Servicios: </p>
        <div class="company-services">
          <ul>
            <li class="value" v-if="company.transporte">Transporte</li>
            <li class="value" v-if="company.carga">Carga</li>
            <li class="value" v-if="company.embalaje">Embalaje</li>
            <li class="value" v-if="company.montaje">Montaje</li>
            <li class="value" v-if="company.desmontaje">Desmontaje</li>
          </ul>
        </div>
      </div>

      <div class="company-services">
        <p class="label">Dirección: </p>
        <p class="value">{{ company.direccion }}</p>
      </div>


      <div class="company-services">
        <p class="label">Contacto: </p>
        <p class="value">Para comunicarse con nosotros, por favor utilice los servicios de mensajería dentro de la aplicación</p>
      </div>

    </template>
  </pv-card>
  
  <!-- FORMULARIO PARA AGREGAR RESERVA -->
  <br>
  <div class="custom-addReservation">
    <div class="panels-container">
    <div class="reservation-panel">
    <pv-panel header="Reservar" toggleable :collapsed="true">
      <form @submit.prevent="submitForm" id="add-reservation" class="reservation-info">

        <!-- reserva info -->
        <label for="bookingDate">Fecha de hoy:</label><br>
        <input type="text" v-model="reservation.bookingDate" id="bookingDate"  required placeholder="Ex. 2023-10-17"><br>
        <label for="services">Servicios:</label><br>
        <input type="text" v-model="reservation.services" id="services"  required placeholder="Ex. Carga"><br>
        <label for="weight">Cantidad de carga:</label><br>
        <input type="text" v-model="reservation.weight" id="weight"  required placeholder="Ex. 100"><br>
        <label for="pickupAddress">Direccion de entrega:</label><br>
        <input type="text" v-model="reservation.pickupAddress" id="pickupAddress" required placeholder="Ex. Avenida Los Incas, Mz. B1 Lt. 5 Pis. 2"><br>
        <label for="destinationAddress">Direccion de destino:</label><br>
        <input type="text" v-model="reservation.destinationAddress" id="destinationAddress"  required placeholder="Ex. Jr. Huaraz 1935, 140"><br>
        <label for="movingDate">Fecha cuando el servicio se lleva a cabo:</label><br>
        <input type="text" v-model="reservation.movingDate" id="movingDate"  required placeholder="Ex. 2023-10-19"><br>
        <label for="movingTime">Hora cuando el servicio se lleva a cabo:</label><br>
        <input type="text" v-model="reservation.movingTime" id="movingTime"  required placeholder="Ex. 14:00"><br>

        <!-- metodo de pago info -->
        <label for="cardNumber">Numero de tarjeta de pago:</label><br>
        <input type="text" v-model="cardNumber" id="cardNumber"  required placeholder="Ex. 1234 5678 9012 3456"><br>
        <label for="cvvCard">CVV de la tarjeta de pago:</label><br>
        <input type="text" v-model="cvvCard" id="cvvCard"  required placeholder="Ex. 123"><br>
        <label for="dateCard">Fecha de vencimiento de la tarjeta:</label><br>
        <input type="text" id="dateCard" v-model="dateCard" required  placeholder="Ex. 10/25"><br>

        
        <div id="errorMessages" class="error-messages" v-html="errorMessage"></div>

        <button type="submit">Realizar reserva</button>

      </form>
    </pv-panel>
  </div>
    <div class="reviews-panel">
      <pv-panel header="Reseñas" toggleable :collapsed="true">

        <div class="average-rating">
          <h2>Calificación general</h2>
          <div class="rating-container"> <!-- Agrega este div -->
            <Rating v-model="company.averageRating" :cancel="false" readonly />
          </div>
          <div class="company-logo-container">
            <img :src="company.photo" alt="logo de empresa" class="company-logo">
          </div>
        </div>

        <div v-for="review in company.reviews" :key="review.id" class="review">

          <Rating v-model="review.rating" :cancel="false" readonly />
          <p>{{ review.comment }}</p>
        </div>
        <div  v-if="company.reviews.length === 0" class="review">
          <p>Actualmente, no hay reseñas disponibles para esta empresa. Sé el primero en compartir tu experiencia.</p>
        </div>
      </pv-panel>
    </div>
    </div>
  </div>

</template>



<style scoped>
.review {
  border: 1px solid #ccc;
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  background-color: #e8eaf6;
}
.review p {
  margin-top: 10px;
}
.average-rating {
  text-align: center;
}
.rating-container {
  align-items: center;
  display: flex;
  justify-content: center;
  margin-top: 20px;
}
.company-logo-container img {
  width: 200px; /* Ajusta esto al tamaño que desees */
  height: auto;
  margin-bottom: 30px;
}
.panels-container {
  display: flex;
  justify-content: space-between;
  width: 100%;
}
.reservation-panel,
.reviews-panel {
  width: 60%; /* Divide el espacio horizontal en dos columnas  */
  max-height: 800px; /* Establece una altura máxima para los paneles */
  overflow-y: auto;
}
/* CARD */
.custom-card {
  width: 80%; /* Ajusta el ancho según tus necesidades */
  max-width: 600px; /* Establece un ancho máximo para evitar que se vuelva demasiado ancho en pantallas grandes */
  margin: 50px auto;
  background-color: #ffffff;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  border-radius: 8px;
  padding: 20px;
  text-align: left;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.custom-card .company-name {
  font-size: 30px;
  font-weight: bold;
  margin: 10px 0;
}

.custom-card img {
  width: 80%; 
  height: auto;
  border-radius: 15px;
  align-self: center;
}

.company-type {
  font-size: 1rem;
  color: #666;
}

.label {
  font-weight: bold;
  font-size: 16px;
}

.value {
  font-size: 16px;
}

/* FORM RESERVATION */
.custom-addReservation {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  margin-top: 20px;
  padding: 20px;
  background-color: #ffffff;
  border-radius: 15px;
  width: 100%;

}



.reservation-info {
  display: flex;
  flex-direction: column;
  margin-top: 10px;
  max-width: 100%;
}

.reservation-info input[type="text"] {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
}

button {
  background-color: #ee8f00;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s ease;
  margin-top: 20px;
}

button:hover {
  background-color: #ee8f00;
}

/*Titulo*/
.title {
  color: #FDAE39;
  font-family: sans-serif;
}
.error-messages {
  color: #ff0000;
  font-weight: bold;
  margin-top: 10px;
}
</style>
