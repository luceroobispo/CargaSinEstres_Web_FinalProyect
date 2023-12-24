<script>
import BoletteCompany from "@/membership/components/boletteCompany.component.vue";
import toolbarCompanyComponent from "@/public/components/toolbarCompany.component.vue";
import {HttpCommonService} from "@/services/http-common.service";

export default {
  name: 'formularyCompany',
  components: {toolbarCompanyComponent},
  computed: {
    BoletteCompany() {
      return BoletteCompany
    }
  },
  data() {
    return {
      company:{
      },
      id: null,
      formData:{
        tipoMembresia: '',
      },
      nombreEmpresa: '',
      ruc: '',
      direction: '',
      tipoMembresia: '',
      tipoTarjeta: this.tipoTarjeta,
      tarjetaVisa: this.tarjetaVisa,
      fechaVencimientoVisa: this.fechaVencimientoVisa,
      cvvVisa: this.cvvVisa,
      paisVisa: this.paisVisa,
      tarjetaMasterCard: this.tarjetaMasterCard,
      fechaVencimientoMasterCard: this.fechaVencimientoMasterCard,
      cvvMasterCard: this.cvvMasterCard,
      paisMasterCard: this.paisMasterCard,
      errorMessage: '',
      membershipuser: new HttpCommonService(),
      apiService: new HttpCommonService()
    };
  },

  created() {
    this.id = this.$route.params.id;

  },

  methods: {
    async submitForm() {
      this.errorMessage = '';
      const formData = {
        tipoMembresia: this.formData.tipoMembresia,
        id: this.id,
        nombreEmpresa: this.nombreEmpresa,
        ruc: this.ruc,
        direction: this.direction,
        tipoTarjeta: this.tipoTarjeta,
        tarjetaVisa: this.tarjetaVisa,
        fechaVencimientoVisa: this.fechaVencimientoVisa,
        cvvVisa: this.cvvVisa,
        paisVisa: this.paisVisa,
        tarjetaMasterCard: this.tarjetaMasterCard,
        fechaVencimientoMasterCard: this.fechaVencimientoMasterCard,
        cvvMasterCard: this.cvvMasterCard,
        paisMasterCard: this.paisMasterCard,
      };

      let warnings = '';

      if (formData.nombreEmpresa.length < 1) {
        warnings += 'El nombre no es válido <br>';
      }

      if (formData.direction.length < 1) {
        warnings += 'La dirección no es válida <br>';
      }

      if (formData.ruc.length < 11) {
        warnings += 'El RUC debe tener 11 dígitos <br>';
      }

      // Agregar validación de campos de tarjeta si es necesario
      if (formData.tipoTarjeta === 'Visa') {
        if (formData.tarjetaVisa.length < 16) {
          warnings += 'Número de tarjeta Visa no válido, debe tener 16 dígitos <br>';
        }
        if (formData.cvvVisa.length < 3) {
          warnings += 'Debe tener 3 dígitos <br>';
        }
        // Agregar validaciones adicionales si es necesario
      } else if (formData.tipoTarjeta === 'Mastercard') {
        if (formData.tarjetaMasterCard.length < 16) {
          warnings += 'Número de tarjeta Visa no válido, debe tener 16 dígitos <br>';
        }
        if (formData.cvvMasterCard.length < 3) {
          warnings += 'Debe tener 3 dígitos <br>';
        }
      }

      this.errorMessage = warnings;

      if (!this.errorMessage) {
        this.updateCompany();
      }
    },

    updateCompany() {
      this.company.id = this.id;
      this.company.tipoMembresia = this.formData.tipoMembresia;
      const tipoMembresiaData = { tipoMembresia: this.formData.tipoMembresia };
      const updatedCompanyData = {
        nombreEmpresa: this.nombreEmpresa,
        ruc: this.ruc,
        direction: this.direction,
        tipoMembresia: this.formData.tipoMembresia,
        tipoTarjeta: this.tipoTarjeta,
        idCompany: this.id,
      };
      this.saveUpdatedCompanyToServer(updatedCompanyData);
    },


    async saveUpdatedCompanyToServer(updatedCompanyData){
      try {
        const response = await this.apiService.createMembership(updatedCompanyData);

        if (response.status === 200) {
          this.$router.push({
            name: 'bolette-company',
            query: {
              nombreEmpresa: this.nombreEmpresa,
              ruc: this.ruc,
              direction: this.direction,
              tipoMembresia: this.formData.tipoMembresia,
              tipoTarjeta: this.tipoTarjeta
            }
          });
        } else {
          console.error('Error al registrar la compra de membresía:', response.data);
        }
      } catch (error) {
        console.error('Error al enviar la solicitud de actualización a la API:', error);
      }
    },
    cancel() {
      this.$router.push({
        path: `/company/${this.id}/company-settings`,
        name:'company-settings',
        params: {
          id: this.id,
        },
      });
    }
  }
};
</script>

<template>
  <div>
    <br>
    <div class="container1">
      <form @submit.prevent="submitForm" id="customer-info" class="left-container">
        <label for="nombre">Nombre de la Empresa:</label><br>
        <input type="text" v-model="nombreEmpresa" required><br>
        <label for="ruc">RUC:</label><br>
        <input type="number" v-model="ruc" required><br>
        <label for="direccion">Dirección:</label><br>
        <input type="text" v-model="direction" required><br>
        <label for="tipoMembresia">Tipo de membresía:</label>
        <select v-model="formData.tipoMembresia" required>
          <option value="35">1 Mes</option>
          <option value="95">3 Meses</option>
          <option value="365">1 Año</option>
        </select><br>
        <label for="tipoTarjeta">Tipo de tarjeta:</label>
        <select v-model="tipoTarjeta" required>
          <option value="Visa">Visa</option>
          <option value="Mastercard">MasterCard</option>
        </select><br><br>
        <!-- Mostrar campos de tarjeta para Visa -->
        <div v-if="tipoTarjeta === 'Visa'">
          <label for="tarjetaVisa">Número de tarjeta Visa:</label>
          <input type="number" v-model="tarjetaVisa" required>
          <label for="fechaVencimientoVisa">Fecha de vencimiento Visa:</label><br>
          <input type="date" v-model="fechaVencimientoVisa" required><br>
          <label for="cvvVisa">CVV Visa:</label>
          <input type="number" v-model="cvvVisa" required>
          <label for="paisVisa">País:</label>
          <input type="text" v-model="paisVisa" required>
        </div>

        <!-- Mostrar campos de tarjeta para MasterCard -->
        <div v-if="tipoTarjeta === 'Mastercard'">
          <label for="tarjetaMasterCard">Número de tarjeta MasterCard:</label>
          <input type="number" v-model="tarjetaMasterCard" required>
          <label for="fechaVencimientoMasterCard">Fecha de vencimiento MasterCard:</label><br>
          <input type="date" v-model="fechaVencimientoMasterCard" required><br>
          <label for="cvvMasterCard">CVV MasterCard:</label>
          <input type="number" v-model="cvvMasterCard" required>
          <label for="paisMasterCard">País:</label>
          <input type="text" v-model="paisMasterCard" required>
        </div>
        <button type="submit">Pagar Ahora</button>
        <button id="cancel-button" type="button" @click="cancel">Cancelar</button>
        <div id="errorMessages" class="error-messages" v-html="errorMessage"></div>
      </form>
      <div class="right-container">
        <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/develop/Proyecto/image/Cargalogo.png?raw=true" alt="Imagen" class="floating-image">
      </div>
    </div>
  </div>
  <br>
</template>

<style>
h2{
  color: #181818;
  font-size: 50px;
}

/* Estilos para el contenedor principal */
.container1 {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
}

/* Estilos para el formulario en la mitad izquierda */
.left-container {
  flex: 3;
  background-color: #e8a300;
  border-radius: 10px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
  padding: 60px;
  margin-right: 20px;
  margin-top: 20px;
  margin-bottom: 20px;
}

/* Estilos para las etiquetas dentro del formulario */
.left-container label {
  font-weight: bold;
  margin-bottom: 10px;
  font-size: 15px;
  width: 90px;
  display: inline-block;
}

input[type="text"] {
  width: 100%;
  padding: 10px;
  margin-bottom: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 12px;
}

input[type="number"] {
  width: 100%;
  padding: 10px;
  margin-bottom: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 12px;
}

/* Estilos para la imagen a la derecha */
.right-container {
  flex: 1;
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
}

/* Estilos para la imagen */
.floating-image {
  width: 150px;
  margin-top: 120px;
  height: 400px;
}
</style>
