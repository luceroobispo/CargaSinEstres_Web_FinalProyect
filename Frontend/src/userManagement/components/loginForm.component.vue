<script>
import { HttpCommonService } from "@/services/http-common.service.js";
import ToolbarHome from "@/public/components/toolbarHome.component.vue";

export default {
  name : "loginForm",
  components: {ToolbarHome},
  data() {
    return {
      emailVerify: '',
      passwordVerify: '',
      loginForm: {
        email: '',
        password: '',
        rememberMe: false
      },
      errorMessage: '',
      apiService: new HttpCommonService(),
    };
  },

  methods: {
    async onSubmit() {
      this.errorMessage = '';
      const loginData = this.loginForm;
      let warnings = '';

      if (!loginData.email || !loginData.password) {
        warnings += 'Se necesitan ambos campos para acceder <br>';
      }

      if (
          !/^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/.test(
              loginData.email
          )
      ) {
        warnings += 'Email incorrecto<br>';
      }

      if (loginData.password.length < 6) {
        warnings += 'Contraseña incorrecta<br>';
      }

      this.errorMessage = warnings;

      if (!this.errorMessage) {


        this.emailVerify = this.loginForm.email;
        this.passwordVerify = this.loginForm.password;

      }

      try {
        const verifyUserCompany ={
          email: this.emailVerify,
          password: this.passwordVerify
        };

        const companyResponse = await this.apiService.getCompaniesForLogin(verifyUserCompany);

        if (companyResponse.data != null) {
          this.$toast.add({
            severity: 'success',
            summary: 'Inicio de sesión exitoso',
            detail: 'Ha iniciado sesión con éxito.',
            life: 5000,
          });
          this.$router.push(`/company/${companyResponse.data.id}/company-settings`);
        } else {
          this.errorMessage = 'Credenciales incorrectas. Intente nuevamente.';
        }
      } catch (error) {
        console.error(error);
        this.errorMessage = 'Ocurrió un error al iniciar sesión. Intente nuevamente.';
      }

      try{
        const verifyUserClient ={
          email: this.emailVerify,
          password: this.passwordVerify
        };

        const clientResponse = await this.apiService.getClientsForLogin(verifyUserClient);

        if(clientResponse.data != null){

          this.$toast.add({
            severity: 'success',
            summary: 'Inicio de sesión exitoso',
            detail: 'Ha iniciado sesión con éxito.',
            life: 5000,
          });
          this.$router.push(`/client/${clientResponse.data.id}/client-settings`);
        }else{
          this.errorMessage = 'Credenciales incorrectas. Intente nuevamente.';
        }

      } catch (error){
        console.error(error);
        this.errorMessage = 'Ocurrió un error al iniciar sesión. Intente nuevamente.';
      }

    },

    cancelar() {
      this.$router.push('/home');
    }
  }
};
</script>

<template>
  <div>
    <toolbarHome></toolbarHome>
  </div>
  <div class="login-form">
    <form @submit.prevent="onSubmit">
      <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/Cargalogo.png?raw=true" class="logo" alt="Logo"/>
      <h1>Carga Sin Estrés</h1>

      <div class="content">
        <div class="input-field">
          <input
              type="email"
              v-model="loginForm.email"
              :name="loginForm.rememberMe ? 'email' : ''"
              :autocomplete="loginForm.rememberMe ? 'username' : ''"
              placeholder="Correo electrónico o Usuario"
              autofocus
          />
        </div>

        <div class="input-field">
          <input
              type="password"
              v-model="loginForm.password"
              :name="loginForm.rememberMe ? 'password' : ''"
              :autocomplete="loginForm.rememberMe ? 'current-password' : ''"
              placeholder="Contraseña"
          />
        </div>
        <!-- Dependiendo del navegador y configuración, Chrome puede requerir estos atributos para mostrar correos guardados. -->

        <div class="remember-me">
          <label>
            <input type="checkbox" v-model="loginForm.rememberMe" /> Mostrar correos
          </label>
        </div>

        <div class="action" id="actionButtons">
          <button id="login-button" type="submit">Iniciar Sesión</button>
          <button id="cancel-button" type="button" @click="cancelar" >Cancelar</button>
        </div>
        <div id="errorMessages" class="error-messages" v-html="errorMessage"></div>

      </div>
    </form>
  </div>
  <br><br><br>
</template>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  -webkit-font-smoothing: antialiased;
}

.login-form .logo {
  width: 150px;
  height: 153px;
  display: block;
  margin: 11px 150px 10px;
}

h1 {
  color: #ffffff;
  font-family: sans-serif;
  font-size: 20px;
  font-style: normal;
  text-align: center;
  margin-top: 2px;
  margin-bottom: 29px;
  font-weight: 400;
  line-height: normal;
  text-transform: uppercase;
}

body {
  background: #d9d9d9;
  font-family: sans-serif;
}

.login-form {
  background: #dfa100;
  width: 460px;
  height: 485px;
  margin: 65px auto;
  display: flex;
  border-radius: 20px;
  border-style: solid;
  border-width: 1px;
  box-shadow: 0 4px 4px 0 rgba(0, 0, 0, 0.25);
}

.login-form .input-field {
  position: relative;
  width: 100%;
}

.login-form .input-field input {
  display: block;
  font-family: sans-serif;
  font-size: 20px;
  width: 90%;
  padding: 8px 60px;
  margin-left: 21px;
  border: 1px solid #FDAE39;
  outline: none;
  transition: all 0.2s;
  border-radius: 10px;
  margin-top: 10px;
}

.input-field input::placeholder {
  color: #858585;
}

.input-field i {
  position: absolute;
  left: 40px;
  top: 50%;
  transform: translateY(-50%);
  font-size: 20px;
  color: #545454;
}

.input-field img {
  max-width: 100%;
  max-height: 100%;
}

.login-form .input-field input:focus {
  border-color: #222;
}

.remember-me {
  display: flex;
  font-size: 20px;
  margin: 10px 0 20px 20px;
}

.remember-me label {
  display: inline-block;
  color: #565656;
  margin-right: 10px;
}

button {
  position: relative;
  padding: 5px;
  margin: 10px auto auto 8%;
  width: 40%;
  color: white;
  background-color: black;
  border: 1px solid #FDAE39;
  border-radius: 4px;
}

button:hover {
  background-color: #FDAE39;
}

.error-messages {
  display: flex;
  justify-content: center;
  align-items: center;
  color: #ff0000;
  font-weight: bold;
  margin-top: 10px;
}

</style>
