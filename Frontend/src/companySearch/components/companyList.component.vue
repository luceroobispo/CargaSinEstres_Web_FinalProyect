<script>
  import { HttpCommonService } from "@/services/http-common.service.js";
  export default{
    name: "companyList",
    data(){
      return{
        companies: [],
        company: {},
        companyService: null,
        userId: null,

        tempCompanies: [],
        originalData: [],

        manualCompanyName: "",

        selectedAverageRating: null,
        averageRatingOptions: [
          { label: 'Sin filtro', value: null },
          { label: '1 estrella', value: 1 },
          { label: '2 estrellas', value: 2 },
          { label: '3 estrellas', value: 3 },
          { label: '4 estrellas', value: 4 },
          { label: '5 estrellas', value: 5 },
          { label: 'Mayor a menor', value: 'desc' },
          { label: 'Menor a mayor', value: 'asc' }
        ],

        selectedServices: [],
        serviceOptions: [
          { label: 'Transporte', value: 'transporte' },
          { label: 'carga', value: 'carga' },
          { label: 'Embalaje', value: 'embalaje' },
          { label: 'Montaje', value: 'montaje' },
          { label: 'Desmontaje', value: 'desmontaje' }
        ],

        searchMethod: 'noFilter',
        searchOptions: [
          { label: 'Mi Ubicación', value: 'userLocation' },
          { label: 'Ubicación Manual', value: 'manualLocation' },
          { label: 'Sin filtro', value: 'noFilter' },
        ],
        manualLocation: '',
        userLocation: '',

        cargaRapidaDialog: false,
        reservation: {
          services: null,
          bookingDate: null,
          pickupAddress: null,
          destinationAddress: null,
          movingDate: null,
          movingTime: null,
          weight: null
        },
        memberships: [],
      };
    },


    created() {
        this.userId = this.$route.params.id;
        this.companyService = new HttpCommonService();

        this.getMemberships()

        this.companyService.getAll()
            .then((response) => {
              const responseData = response.data;
              if (this.originalData.length === 0) {
                this.originalData = [...responseData];
              }

              this.tempCompanies = [...this.originalData];

              this.companies = this.originalData;
            });

        this.getUserDistrict();
        this.searchByName();
        this.searchByServices();
        this.searchByLocation();
        this.searchByAverageRating();
    },


    methods:{
      getMemberships(){
        this.memberships = this.companyService.getAllMemberships()
            .then((response) => {
              this.memberships = response.data;});
      },
      getUserDistrict() {
        this.companyService.getClientById(this.userId)
        .then((response) => {
          const responseData = response.data;
          this.userLocation = responseData.direccion;
        });
      },

      handleRowClick(event) {
        setTimeout(() => {
          const companyId = event.data.id;
          const companyData= JSON.stringify(event.data);
          this.$router.push({
            path: `/company/${companyId}`,
            name: "company-detail",
            params:{
              id: companyId,
            },
            query:{
              companyData,
            }
          });
        });
      },

      applyOtherFilters() {
        this.companies = this.originalData.filter((company) => {
          return (
              (!this.selectedServices.length || this.selectedServices.every((selectedService) => company[selectedService.value])) &&
              (!this.manualCompanyName.trim() || company.name.toLowerCase().includes(this.manualCompanyName.toLowerCase())) &&
              (this.selectedAverageRating === null || (company.averageRating || 0) === this.selectedAverageRating.value) &&
              (!this.manualLocation.trim() || company.direccion.toLowerCase().includes(this.manualLocation.toLowerCase()))
          );
        });
      },

      searchByName() {
        if (this.manualCompanyName.trim() === "") {
          this.companies = [...this.tempCompanies];
        } else {
          this.companies = this.tempCompanies.filter((company) => {
            return company.name.toLowerCase().includes(this.manualCompanyName.toLowerCase());
          });
          this.tempCompanies = [...this.companies];

        }
        this.applyOtherFilters();


      },

      searchByServices() {
        if (this.selectedServices.length === 0) {
          this.companies = this.originalData;
        } else {
          this.companies = this.originalData.filter((company) => {
            return this.selectedServices.every((selectedService) => company[selectedService.value]);
          });
          this.tempCompanies = [...this.companies];
          this.applyOtherFilters();
        }

      },

      searchByLocation() {
        if (this.searchMethod.value === 'userLocation') {
          this.companies = this.originalData.filter((company) => {
            return company.direccion.toLowerCase().includes(this.userLocation.toLowerCase());
          });
          this.tempCompanies = [...this.companies];
          this.applyOtherFilters();
        } else if (this.searchMethod.value === 'manualLocation') {
          this.companies = this.originalData.filter((company) => {
            return company.direccion.toLowerCase().includes(this.manualLocation.toLowerCase());
          });
          this.tempCompanies = [...this.companies];
          this.applyOtherFilters();
        } else if(this.manualLocation === ''){
          this.companies = [...this.tempCompanies];
          this.searchMethod = '';
        } else {
          this.companies = [...this.tempCompanies];
          this.searchMethod = '';
        }
      },

      searchByAverageRating() {


        if (this.selectedAverageRating && typeof this.selectedAverageRating.value === 'number') {
          this.companies = this.originalData.filter((company) => {
            const averageRating = company.averageRating || 0;
            return averageRating === this.selectedAverageRating.value;
          });
        } else if (this.selectedAverageRating && this.selectedAverageRating.value === 'desc') {
          this.companies = [...this.originalData];
          this.companies.sort((a, b) => (b.averageRating || 0) - (a.averageRating || 0));
          this.tempCompanies = [...this.companies];
          this.applyOtherFilters();
        } else if (this.selectedAverageRating && this.selectedAverageRating.value === 'asc') {
          this.companies = [...this.originalData];

          this.companies.sort((a, b) => (a.averageRating || 0) - (b.averageRating || 0));
          this.tempCompanies = [...this.companies];
          this.applyOtherFilters();
        } else {
          this.companies = this.originalData;
          this.selectedAverageRating = null;
        }
      },

      CargaRapida(){
        let now = new Date();
        let Year = now.getFullYear();
        let Month = now.getMonth() + 1;
        let Day = now.getDate();
        let formattedDate = `${Year}-${Month.toString().padStart(2, '0')}-${Day.toString().padStart(2, '0')}`;
        let currentHour = now.getHours();
        let currentMinute = now.getMinutes();

        let randCompanyIndex = Math.floor(Math.random() * this.companies.length);
        let randomCompany = this.companies[randCompanyIndex];

        this.reservation.bookingDate= formattedDate;
        this.reservation.services="Carga";
        this.reservation.pickupAddress = this.userLocation;
        this.reservation.destinationAddress= "Por definirse";

        this.reservation.movingDate = formattedDate;
        this.reservation.movingTime = currentHour + ":" + currentMinute;
        this.reservation.weight = 0;

        this.addReservation(this.userId, randomCompany.id);
        this.mostrarMensajeCargaRapidaEnProceso();
        this.$router.push({path: `/client/${this.userId}/client-booking-history`});
      },

      mostrarMensajeCargaRapidaEnProceso() {
        this.$toast.add({
          severity: "info",
          summary: "Carga Rápida en proceso",
          detail: "Tu solicitud de carga rápida se está procesando. Por favor, espera.",
          life: 5000,
        });
      },

      addReservation(userId, companyId){
        this.cargaSinEstres_service = new HttpCommonService();

        this.cargaSinEstres_service.createReservation(userId, companyId, this.reservation)
            .then((response) => {

              this.$data.reservation = response.data;
            });
      },

      OpenDialog(){
        this.cargaRapidaDialog = true;
      },

      hideDialog(){
        this.cargaRapidaDialog = false;

      },

    }
  }
</script>

<template>
  <br>
  <div>
    <div><h1 class="title flex justify-content-center">Búsqueda de empresas</h1></div>
    <br><br>

    <div class="card">

      <pv-data-table ref="dt" :value="companies" dataKey="id"
                     :paginator="true" :rows="10"
                     paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                     :rowsPerPageOptions="[5, 10, 25]"
                     currentPageReportTemplate="Se muestra {first} - {last} de {totalRecords} empresas"
                     responsiveLayout="scroll"
                     @row-click="handleRowClick"
      >

        <template #header>

          <div class="table-header flex flex-column md:flex-row md:justify-content-between">

            <div class="div1">
              <!--Buscar por servicios de empresa-->
              <div class="p-field p-fluid">
                  <pv-multiselect
                    v-model="selectedServices"
                    :options="serviceOptions"
                    optionLabel="label"
                    placeholder="Selecciona servicios"
                    class="w-full md:w-20rem"
                    @change="searchByServices"
                ></pv-multiselect>
              </div>

              <!-- Selector para elegir método de búsqueda -->
              <div class="p-field p-fluid">
                  <pv-dropdown
                      v-model="searchMethod"
                      @change="searchByLocation"
                      class="w-full md:w-14rem"
                      :options="searchOptions"
                      optionLabel="label"
                      placeholder="Selecciona ubicación"
                  />
              </div>

              <!-- Buscar por ubicación -->
              <div class="p-field p-fluid" v-if="searchMethod.value === 'manualLocation'">
                <div class="p-input-icon-left ">
                  <i class="pi pi-search" />
                  <pv-input-text v-model="manualLocation" @input="searchByLocation" placeholder="Dirección"></pv-input-text>
                </div>
              </div>

            </div>
            
            <div class="div2">
              <!--Buscar por nombre de empresa-->
              <div class="p-input-icon-left p-field p-fluid">
                <i class="pi pi-search" />
                <pv-input-text v-model="manualCompanyName" @input="searchByName" placeholder="Nombre" />
              </div>

              <!--Buscar por calificación promedio de empresa-->
              <div class="p-field p-fluid">
                <pv-dropdown
                    v-model="selectedAverageRating"
                    :options="averageRatingOptions"
                    optionLabel="label"
                    placeholder="Selecciona el filtro de calificación"
                    @change="searchByAverageRating"
                />
              </div>

              <!--Buscar por carga rapida-->
              <pv-button icon="pi pi-plus" label="Carga Rapida" class="p-button-success p-mr-2" @click="OpenDialog"></pv-button>
              
            </div>
            
          </div>
        </template>

        <pv-column field="id" header="Id" :sortable="true" style="min-width: 10rem"></pv-column>
        <pv-column field="name" header="Nombre" :sortable="true" style="min-width: 12rem"></pv-column>
        <pv-column field="services" header="Servicios" style="min-width: 20rem">
          <template #body="slotProps">
            <span v-show="slotProps.data.transporte">Transporte, </span>
            <span v-show="slotProps.data.carga">Carga, </span>
            <span v-show="slotProps.data.embalaje">Embalaje, </span>
            <span v-show="slotProps.data.montaje">Montaje, </span>
            <span v-show="slotProps.data.desmontaje">Desmontaje</span>
          </template>
        </pv-column>
        <pv-column field="direccion" header="Dirección" :sortable="true" style="min-width: 12rem"></pv-column>


        <pv-column field="photo" header="Logo" style="min-width: 20rem">
          <template #body="slotProps">
            <img :src="slotProps.data.photo" alt="Logo" class="w-4 h-4 rounded-full">
          </template>
        </pv-column>

      </pv-data-table>
    </div>
  </div>

  <pv-dialog :visible="cargaRapidaDialog" :modal="true" :closable="false" :style="{width: '600px'}">
    <div class="dialog-container">
      <div class ="dialog-section">
        <h2 class="dialog-title">Carga Rapida</h2>
        <button aria-label="Cancelar Carga Rapida" icon="pi pi-times" class="btn-cerrar p-button-text" @click="hideDialog">Cancelar</button>
      </div>

      <div class ="dialog-section">
        <p> Pulsa el botón para buscar <br>
            servicios de carga rápidamente en tu puerta<br>
            y nuestras empresas afiliadas podran responder a tu llamado</p>
      </div>

      <div class ="dialog-section">
        <button aria-label="Buscar Carga Rapida" icon="pi pi-search" class="btn-CargaRapida p-button-text" @click="CargaRapida">Carga Rapida</button>
      </div>
    </div>
  </pv-dialog>
  
</template>


<style scoped>
/*Titulo*/
.title {
  color: #FDAE39;
  font-family: sans-serif;
}

/* Estilos para la parte izquierda (div1) de table-header */
.table-header .div1 {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  width: 100%;
  padding: 1rem;
  background-color: #f4f4f4;
  border-radius: 5px;
}

/* Estilos para la parte derecha (div2) de table-header */
.table-header .div2 {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-start;
  width: 100%;
  padding: 1rem;
  background-color: #f4f4f4;
  border-radius: 5px;
}

/* Estilo común para campos de búsqueda */
.p-field.p-fluid {
  margin: 0.5rem;
  display: inline-block;
  width: 100%; 
}

/* Estilos para input y dropdown */
.p-inputtext, .p-dropdown .p-dropdown-label, .p-multiselect .p-multiselect-label-container {
  font-size: 1rem;
  border: none;
  border-bottom: 2px solid #333;
  border-radius: 0;
  padding: 0.5rem;
  background-color: transparent;
  color: #333;
  transition: border-color 0.3s;
  width: 100%; /* Asegura que todos los elementos tengan el mismo ancho */
}


/* Búsqueda */
.pi-search {
  font-size: 1.2rem;
  color: #666;
}

.p-inputtext:focus {
  border-color: #FDAE39;
}


/* Menú desplegable */
.p-dropdown .p-dropdown-label {
  background-color: transparent;
  border: none;
  border-bottom: 2px solid #333;
  border-radius: 0;
  color: #333;
}


/* Cambiar color de la línea inferior en el enfoque */
.p-dropdown .p-dropdown-label:focus {
  border-color: #FDAE39;
}


/* Botón de búsqueda */
.p-multiselect .p-multiselect-label {
  font-size: 1rem;
  color: #333;
  background-color: transparent;
  border: none;
  border-bottom: 2px solid #333;
  border-radius: 0;
}


/* Cambiar color de la línea inferior en el enfoque */
.p-multiselect .p-multiselect-label:focus {
  border-color: #FDAE39;
}

.card {
  margin: 0 auto;
  width: 80%;
}

/* Estilos para el dialogo */
.dialog-container {
  font-weight: bold;
  font-size: 18px;
  margin-bottom: 16px;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
}


.dialog-section {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  margin-top: 16px;
  width: 90%;
}

.btn-cerrar{
  position: relative;
  padding: 5px;
  margin: 20px;
  width: 20%;
  color: grey;
  background-color: white;
  border: 1px solid #FDAE39;
  border-width: 2px;
  border-radius: 4px;
}


.btn-CargaRapida {
  
  padding: 5px;
  margin: 20px;
  position: relative;
  width: 100%;
  color: white;
  background-color: black;
  border: 1px solid #FDAE39;
  border-width: 4px;
  border-radius: 4px;
}


.dialog-title{
  margin-right: 1rem;
}

.p-multiselect .p-multiselect-label-container {
  width: 100%; 
}
</style>
