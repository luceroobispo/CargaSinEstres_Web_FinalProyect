<script>

export default {
  name: "toolbarBolette",
  data() {
    return {
      drawer: false,
      items: [
        { label: "Inicio", to: "/" },
        { label: 'Editar Perfil', to: `/company/${this.userId}/company-settings` },
      ],
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
    goToHome() {
      this.$router.push({
        path: `/`,
        name: 'home',
      });
    },
    goToCompanySettings() {
      this.$router.push({
        path: `/company/${this.userId}/company-settings`,
        name: 'client-settings',
        params: {
          id: this.userId,
        },
      });
    }
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
            <router-link
                v-for="item in items"
                :to="item.to"
                custom
                v-slot="{ navigate, href }"
                :key="item.label"
            >
              <pv-button
                  class="p-button-text text-white"
                  :href="href"
                  @click="navigate">
                {{ item.label }}
              </pv-button>
            </router-link>
            <pv-button @click="goToHome" class="p-button-text text-white">Inicio</pv-button>
            <pv-button @click="goToCompanySettings" class="p-button-text text-white">Editar Perfil</pv-button>
          </div>
        </template>
      </pv-toolbar>
    </header>
    <br><br><br><br><br>
    <RouterView />
  </div>
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
