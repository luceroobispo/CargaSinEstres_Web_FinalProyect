<script>

export default {
  name: "toolbarCompany",
  data() {
    return {
      drawer: false,
      userId: '',
      userType: '',
    };
  },
  created() {

    // Obtiene el id del usuario
    this.userId = this.$route.params.id;

    // Obtiene el tipo de usuario
    const routeParts = this.$route.path.split('/');
    this.userType = routeParts[1];
  },
  methods: {
    goToMembershipForm() {
      this.$router.push({
        path: `/company/${this.userId}/formulary`,
        name: 'formulary-company',
        params: {
          id: this.userId,
        },
      });
    },
    goToCompanySettings() {
      this.$router.push({
        path: `/company/${this.userId}/company-settings`,
        name: 'company-settings',
        params: {
          id: this.userId,
        },
      });
    },
    goToBookingHistory() {
      this.$router.push({
        path: `/company/${this.userId}/company-booking-history`,
        name: 'company-booking-history',
        params: {
          id: this.userId,
        },
      });
    },
    logOut() {
      this.$router.push({
        path: '/home',
        name: 'home',
      });
    },
  }
}

</script>

<template>
  <div>
    <pv-toast></pv-toast>
    <header>
      <pv-toolbar class="bg-black">
        <template #start>
          <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/develop/Proyecto/image/Cargalogo.png?raw=true" alt="Imagen" style="height: 70px">
        </template>
        <template #end>
          <div class="flex-column">
            <pv-button @click="goToMembershipForm" class="p-button-text text-white">Membresia</pv-button>
            <pv-button @click="goToCompanySettings" class="p-button-text text-white">Editar Perfil</pv-button>
            <pv-button @click="goToBookingHistory" class="p-button-text text-white">Historial de Reservas</pv-button>
            <pv-button @click="logOut" class="p-button-text text-white">Cerrar Sesion</pv-button>
          </div>
        </template>
      </pv-toolbar>
    </header>
  </div>
  <br><br><br><br><br>
  <router-view></router-view>
</template>

<style scoped>
.bg-black {
  background-color: #1f1e1e;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
}
</style>
