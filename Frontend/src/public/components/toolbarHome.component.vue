<script>
export default {
  name: "toolbarHome",
  data() {
    return {
      drawer: false,
      items: [
        { label: "Inicio", to: "/" },
      ],
    };
  },
};
</script>

<template>
  <div>
    <pv-toast></pv-toast>
    <header>
      <pv-toolbar class="navbar navbar-expand-md navbar-light fixed-top">
        <template #start>
          <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/Cargalogo.png?raw=true" alt="Imagen" style="height: 40px">
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
        </template>
        <template #end>
          <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav ml-auto">
              <li class="nav-item"><router-link to="/home" class="nav-link">Inicio</router-link></li>
              <li class="nav-item"><a class="nav-link" href="/home#services">Servicio</a></li>
              <li class="nav-item"><a class="nav-link" href="/home#aboutus">Sobre Nosotros</a></li>
              <li class="nav-item"><a class="nav-link" href="/home#plans">Planes</a></li>
              <li class="nav-item"><a class="nav-link" href="/home#testimonials">Testimonios</a></li>
              <li class="nav-item"><router-link to="/login" class="btn btn-outline-dark">Iniciar Sesión</router-link></li>
              <li class="nav-item"><router-link to="/register-client" class="btn btn-outline-orange">Registrar Cliente</router-link></li>
              <li class="nav-item"><router-link to="/register-company" class="btn btn-outline-orange">Registrar Empresa</router-link></li>
            </ul>
          </div>
        </template>
      </pv-toolbar>
    </header>
    <br><br><br>
    <router-view />
  </div>
</template>

<style scoped>
/* Estilos para la barra de navegación */
.navbar {
  background-color: #1f1e1e;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
}

.navbar-toggler {
  background-color: #ffffff !important;
  margin-left:300px;
}

.navbar-toggler-icon {
  color: #ffffff !important;
}

.navbar-nav .nav-item {
  margin-right: 20px;
}

.nav-link {
  color: #ffffff !important;
}

.btn-outline-dark {
  color: #ffffff;
  background-color: #000000;
  border-color: #000000;
  margin-left: 10px;
}

.btn-outline-dark:hover {
  color: #ffffff;
  background-color: #ff8800;
  border-color: #ffffff;
}

.btn-outline-orange {
  color: #fff;
  background-color: #ff8800;
  border-color: #ff8800;
  margin-left: 10px;
}

.btn-outline-orange:hover {
  color: #ff8800;
  background-color: #30302f;
  border-color: #ff8800;
}
</style>
