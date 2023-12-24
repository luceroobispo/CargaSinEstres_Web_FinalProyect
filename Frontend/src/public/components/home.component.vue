<script>
import ToolbarHome from "@/public/components/toolbarHome.component.vue";

export default {
  name: "home",
  components: {ToolbarHome},
  data() {
    return {
      precioMembresia1: 35, // Precio de membresía para 1 mes
      precioMembresia2: 95, // Precio de membresía para 3 meses
      precioMembresia3: 365, // Precio de membresía para 1 año
    };
  },
  methods: {
    redirectToForm(membresiaType) {
      this.$router.push({ path: '/formulario', query: { type: membresiaType } });
    },
  },
}
</script>

<template>
  <a href="https://wa.me/51950457066?text=Me%20gustaría%20saber%20los%20planes%20que%20ofrecen" class="whatsapp" target="_blank"> <i class="fa fa-whatsapp whatsapp-icon"></i></a>
  <div class="w-full">
    <toolbar-home></toolbar-home>
    <div class="landing-page">
      <div id="presentation" class="presentation">
        <br><br><br>
        <div class="container">
          <div class="row">
            <div class="col-md-6">
              <br>
              <div class="presentation-box">
                <br>
                <h1 >Carga sin Estrés</h1>
                <h2>Tu traslado, nuestro compromiso</h2>
                <br>
              </div>
              <br>
            </div>
          </div>
        </div>
      </div>
      <div id="services" class="services">
        <div class="container">
          <h2 class="text-center">SERVICIO DE LA APLICACIÓN</h2>
          <div class="row">
            <div class="col-md-6">
              <div class="service-box">
                <div class="service-icon">
                  <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/icon1.webp?raw=true" alt="Ícono 1">
                </div>
                <h3><b>Carga Rápida</b></h3>
                <p>Descubre servicios de carga disponibles en tu zona al momento de tu mudanza.</p>
              </div>
            </div>
            <div class="col-md-6">
              <div class="service-box">
                <div class="service-icon">
                  <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/icon2.png?raw=true" alt="Ícono 2">
                </div>
                <h3><b>Reserva de Servicios</b></h3>
                <p>Planea tu mudanza junto a la empresa que solicites, y define todos los detalles desde la comodidad de tu hogar.</p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div id="aboutus" class="about-us">
        <div class="container">
          <h2 class="text-center">SOBRE NOSOTROS</h2>
          <div class="row">
            <div class="col-md-6">
              <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/logo1.png?raw=true" alt="Logo" class="about-us-logo">
            </div>
            <div class="col-md-6">
              <br><br>
              <div class="about-us-description">
                <h3>Descripción de la Empresa</h3>
                <p>"Somos más que una empresa de mudanzas; somos tus socios en el emocionante viaje hacia un
                  nuevo capítulo de tu vida. Nuestro equipo apasionado está dedicado a brindarte un servicio
                  excepcional, asegurando que cada paso de tu mudanza esté respaldado por profesionalismo,
                  cuidado y confianza. Nuestra misión es superar tus expectativas, aliviarte de las preocupaciones
                  y convertir cada mudanza en una experiencia positiva e inolvidable."</p>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <div class="video-container d-flex justify-content-center">
                <iframe
                    width="560"
                    height="315"
                    src="https://www.youtube.com/embed/wAuSouCqarw"
                    frameborder="0"
                    allowfullscreen
                ></iframe>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div id="plans" class="plans">
        <div class="container">
          <h2 class="text-center">PLANES PARA EMPRESA</h2>
          <h1>Seleccione su tipo de membresía:</h1>
          <div class="row">
            <div class="col-md-4">
              <div class="plan-box">
                <div @click="redirectToForm('35')"><h3>1 Mes</h3></div>
                <hr>
                <br><p> Esta membresía volverá a tu empresa una destacada dentro de Carga Sin Estrés, entre otros beneficios. </p><br>
                <hr>
                <p> Precio: S/ {{ precioMembresia1 }} </p>
              </div>
            </div>
            <div class="col-md-4">
              <div class="plan-box">
                <div @click="redirectToForm('95')"><h3>3 Meses</h3></div>
                <hr>
                <br><p> Esta membresía volverá a tu empresa una destacada dentro de Carga Sin Estrés, entre otros beneficios. </p><br>
                <hr>
                <p> Precio: S/ {{ precioMembresia2 }} </p>
              </div>
            </div>
            <div class="col-md-4">
              <div class="plan-box">
                <div @click="redirectToForm('365')"><h3>1 Año</h3></div>
                <hr>
                <br><p> Esta membresía volverá a tu empresa una destacada dentro de Carga Sin Estrés, entre otros beneficios. </p><br>
                <hr>
                <p> Precio: S/ {{ precioMembresia3 }} </p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div id="testimonials" class="testimonials">
        <div class="container">
          <h2 class="text-center">TESTIMONIOS</h2>
          <div class="row">
            <div class="col-md-4">
              <div class="testimonial-box">
                <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/testimonial1.png?raw=true" alt="Testimonio 1" class="testimonial-img">
                <p>"Estoy extremadamente impresionado con el servicio de la empresa de mudanzas. ¡Recomiendo
                  encarecidamente sus servicios a cualquiera que necesite una mudanza!"<br><br>Juan Pérez</p>
              </div>
            </div>
            <div class="col-md-4">
              <div class="testimonial-box">
                <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/testimonial2.png?raw=true" alt="Testimonio 2" class="testimonial-img">
                <p>"Quiero expresar mi gratitud a la empresa de mudanzas por brindarme un servicio excelente. Si
                  estás buscando una empresa confiable para tu mudanza, no busques más."<br><br>Roberto Fernández</p>
              </div>
            </div>
            <div class="col-md-4">
              <div class="testimonial-box">
                <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/testimonial3.png?raw=true" alt="Testimonio 3" class="testimonial-img">
                <p>"Nunca pensé que una mudanza podría ser tan fluida hasta que encontré esta empresa. Definitivamente
                  volveré a elegirlos en el futuro y los recomendaré a mis amigos y familiares."<br><br>María González</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<style scoped>
/* Estilos para la sección de presentación */
.presentation {
  padding: 100px 0;
  background-image: url('https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/fondo.jpeg?raw=true');
  background-size: cover;
  background-position: center;
  color: #fff;
  text-align: center;
}

.presentation-box {
  background-color: rgba(255, 149, 0, 0.7);
  padding: 20px;
  border-radius: 10px;
  margin-right: 30px;
}

.presentation-box h1 {
  color: #fff;
}

.presentation-box h2 {
  color: #141313;
}

.video-container {
  text-align: center;
}

/* Estilos para la sección de servicios */
.services {
  padding: 100px 0;
  background-color: #1f1e1e;
}

.services h2 {
  color: #ffffff;
}

.service-box {
  background-color: #ff8800;
  border: 1px solid #ff8800;
  border-radius: 20px;
  padding: 40px;
  margin-top: 30px;
  color: #000000;
  transition: transform 0.3s ease-in-out;
  cursor: pointer;
  text-align:center;
}

.service-box:hover {
  transform: scale(1.05);
}

.service-icon {
  width: 100px;
  height: 100px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 10px;
}

.service-icon img {
  max-width: 100%;
  max-height: 100%;
}

/* Estilos para la sección "Sobre Nosotros" */
.about-us {
  padding: 100px 0;
  background-color: #fff;
}

.about-us h2 {
  color: #333;
}

.about-us-logo {
  max-width: 70%;
  height: auto;
  display: block;
  margin: 0 auto;
}

.about-us-description {
  background-color: #f2f2f2;
  border: 1px solid #ccc;
  border-radius: 10px;
  padding: 20px;
  color: #333;
  text-align:center;
}

/* Estilos para la sección "Planes para Empresa" */
.plans {
  padding: 100px 0;
  background-color: #1f1e1e;
}

.plans h2 {
  color: #ffffff;
}

.plans h1 {
  color: #ffffff;
  text-align:center;
}

.plan-box {
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 10px;
  padding: 20px;
  text-align: center;
  color: #333;
  margin-top: 30px;
  transition: transform 0.3s ease-in-out;
  cursor: pointer;
}

.plan-box:hover {
  transform: scale(1.05);
}

/* Estilos para la sección de "Testimonios" */
.testimonials {
  padding: 100px 0;
  background-color: #fff;
}

.testimonials h2 {
  color: #333;
}

.testimonial-box {
  background-color: #3e3e3e;
  border: 1px solid #000000c5;
  border-radius: 10px;
  padding: 20px;
  text-align: center;
  color: #ffffff;
  margin-top: 30px;
}

.testimonial-img {
  width: 80px;
  height: 80px;
  border-radius: 50%;
  margin-bottom: 10px;
}

/* Estilos para el botón de WhatsApp */
.whatsapp {
  position:fixed;
  width:50px;
  height:50px;
  bottom:40px;
  left:40px;
  background-color:#25d366;
  color:#FFF;
  border-radius:70px;
  text-align:center;
  font-size:30px;
  z-index:100;
}

.whatsapp-icon {
  margin-top:12px;
}

</style>
