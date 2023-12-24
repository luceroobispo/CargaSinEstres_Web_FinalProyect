<script>
import toolbarCompany from "@/public/components/toolbarCompany.component.vue";
import { HttpCommonService } from "@/services/http-common.service.js";

export default {
  name: 'companySettingsForm',
  components: {toolbarCompany},

  data() {
    return {
      company:{
        name: '',
        email: '',
        direccion: '',
        numeroContacto: '',
        confirmarPassword:'',
        password: '',
        photo: '', //link como enlace en texto
        transporte: false,
        carga: false,
        embalaje: false,
        montaje: false,
        desmontaje: false,
        description: '',
        id: '',
      },
      companyUpdate:{
        name: '',
        email: '',
        direccion: '',
        numeroContacto: '',
        confirmarPassword:'',
        password: '',
        photo: '', //link como enlace en texto
        transporte: false,
        carga: false,
        embalaje: false,
        montaje: false,
        desmontaje: false,
        description: '',
        id: '',
      },
      /*confirmarPassword: '',*/
      errorMessage: '',
      id: '',
      formData:{
        name: '',
        email: '',
        direccion: '',
        numeroContacto: '',
        password: '',
        confirmarPassword: '',
        photo: '', //link como enlace en texto
        transporte: false,
        carga: false,
        embalaje: false,
        montaje: false,
        desmontaje: false,
        description: '',
      },
      apiService: new HttpCommonService(),
      companyList: [],
    };
  },

  created() {
    console.log("created");
    this.id = this.$route.params.id;

  },

  methods: {

    onSubmit() {
      this.errorMessage = '';
      /*const formData = {
        name: this.formData.name,
        email: this.formData.email,
        direccion: this.formData.direccion,
        numeroContacto: this.formData.numeroContacto,
        password: this.formData.password,
        confirmarPassword: this.formData.confirmarPassword,
        photo: this.formData.photo,
        transporte: this.formData.transporte,
        carga: this.formData.carga,
        embalaje: this.formData.embalaje,
        montaje: this.formData.montaje,
        desmontaje: this.formData.desmontaje,
        description: this.formData.description,
        id: this.id,
      };*/

      let warnings = '';

      if (this.formData.name.length < 1) {
        warnings += 'El nombre no es válido <br>';
      }

      if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(this.formData.email)) {
        warnings += 'El email no es válido <br>';
      }

      if (this.formData.direccion.length < 1) {
        warnings += 'La dirección no es válida <br>';
      }

      if (!/^\d+$/.test(this.formData.numeroContacto)) {
        warnings += 'El número de contacto no es válido <br>';
      }

      if (this.formData.password.length < 6) {
        warnings += 'La contraseña debe tener al menos 6 caracteres <br>';
      }

      if (this.formData.password !== this.formData.confirmarPassword) {
        warnings += 'Las contraseñas no coinciden <br>';
      }

      this.errorMessage = warnings;

      if (!this.errorMessage) {
        this.updateCompany();
      }
    },

    updateCompany(){
      this.company.name = this.formData.name;
      this.company.email = this.formData.email;
      this.company.direccion = this.formData.direccion;
      this.company.numeroContacto = this.formData.numeroContacto;
      this.company.password = this.formData.password;
      this.company.confirmarPassword = this.formData.confirmarPassword;
      this.company.photo = this.formData.photo;
      this.company.transporte = this.formData.transporte;
      this.company.carga = this.formData.carga;
      this.company.embalaje = this.formData.embalaje;
      this.company.montaje = this.formData.montaje;
      this.company.desmontaje = this.formData.desmontaje;
      this.company.description = this.formData.description;
      this.company.id = this.id;
      this.saveUpdatedCompanyToServer();

    },

    async saveUpdatedCompanyToServer(){
      try {
        const response = await this.apiService.updateCompany(this.company.id , this.company);

        if (response.status === 200) {
          this.$toast.add({
            severity: 'success',
            summary: 'Actualización exitosa',
            detail: 'Se ha actualizado los datos con éxito.',
            life: 5000,
          });

        } else {
          this.$toast.add({
            severity: 'error',
            summary: 'Error al actualizar los datos de tu empresa',
            detail: 'No se pudieron actualizar los datos.',
            life: 5000,
          });
        }
      } catch (error) {
        //console.error('Error al actualizar los datos de la empresa:', error);
      }
    },

    cancel() {
      this.$router.push({
        path: `/company/${this.id}/company-booking-history`,
        name: 'company-booking-history',
        params: {
          id: this.id,
        },
      });
    },

  },
};
</script>

<template>
  <div class="container">
    <div class="container-back">
      <div class="user-info">
        <form @submit.prevent="onSubmit">
          <h2>Editar Datos de Perfil de Empresa</h2>
          <div class="right-section">
            <input type="text" placeholder="Nombre de la empresa" v-model="company.name" id="name"/>
            <input type="text" placeholder="Email" v-model="company.email" id="email"/>
            <input type="text" placeholder="Dirección" v-model="formData.direccion" id="direccion"/>
            <input type="text" placeholder="Teléfono" v-model="formData.numeroContacto" pattern="[0-9]+" id="numeroContacto"/>
            <input class="text-xs" type="password" placeholder="Contraseña" v-model="formData.password" id="password"/>
            <input class="text-xs" type="password" placeholder="Confirmar contraseña" v-model="formData.confirmarPassword" id="confirmarpassword"/>
            <input type="text" placeholder="Link a la imagen" v-model="formData.photo" id="photo"/>
          </div>

          <div class="service-boxes">
            <p>Marque los servicios que ofrece su empresa:</p>
            <div class="checkboxes col">
              <div class="check row-1">
                <input type="checkbox" name="transporte" v-model="formData.transporte" value="transporte"/>&nbsp;
                <label for="transporte">Transporte</label>
              </div>

              <div class="check row-1">
                <input type="checkbox" name="carga" v-model="formData.carga" value="carga"/>&nbsp;
                <label for="carga">Carga</label>
              </div>

              <div class="check row-1">
                <input type="checkbox" name="embalaje" v-model="formData.embalaje" value="embalaje"/>&nbsp;
                <label for="embalaje">Embalaje</label>
              </div>

              <div class="check row-1">
                <input type="checkbox" name="montaje" v-model="formData.montaje" value="montaje"/>&nbsp;
                <label for="montaje">Montaje</label>
              </div>

              <div class="check row-1">
                <input type="checkbox" name="desmontaje" v-model="formData.desmontaje" value="desmontaje"/>&nbsp;
                <label for="desmontaje">Desmontaje</label>
              </div>
            </div>
          </div>

          <div class="description-box">
            <label for="description">Descripción corta de la empresa:</label>
            <textarea name="description" v-model="formData.description" rows="6"></textarea>
          </div>

          <button id="submitButton" type="submit">Guardar cambios</button>
          <button id="cancelButton" type="button" @click="cancel">Cancelar</button>
          <div id="errorMessages" class="error-messages" v-html="errorMessage"></div>
        </form>
      </div>
    </div>
  </div>
  <br><br>

</template>

<style scoped>
body {
  font-family: Arial, sans-serif;
  background-color: #ffffff;
  margin: 0;
  padding: 0;
}

.container {
  max-width: 1000px;
  margin: 5rem auto;
  padding: 20px;
  background-color: #d9d9d9;
  border-radius: 10px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
  position:relative;
}

.container-back {
  max-width: 900px;
  margin: 0 auto;
  padding: 20px;
  background-color: #fff9f9;
  border: 2px solid #000000;
  border-radius: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
  display: flex;
  justify-content: center;
  align-items: center;
}

.user-info {
  display: flex;
  align-items: center;
  margin-top: 10px;
  margin-bottom: 10px;
}

.right-section {
  flex: 1;
  padding-left: 40px;
}

input[type="text"],
input[type="password"],
input[type="email"],
select {
  width: 90%;
  padding: 10px;
  margin-bottom: 10px;
  margin-top: 10px;
  border: 1px solid #FDAE39;
  border-radius: 5px;
}

.service-boxes{
  max-width: 80%;
  margin: auto auto 20px auto;
  display: flex;
  flex-direction: column;
}

.service-boxes .checkboxes{
  border-radius: 5px;
  border: 1px solid #FDAE39;
  background-color: white;
  display: flex;
  flex-direction: column;
}

.description-box{
  display: flex;
  flex-direction: column;
}

.description-box label{
  margin-left: 10%;
}

.description-box textarea{
  margin: auto;
  border-radius: 5px;
  border: 1px solid #FDAE39;
  width: 80%;
}

button {
  width: 180px;
  background-color: #000000;
  color: #fff;
  font-size: 18px;
  padding: 5px 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  align-self: flex-start;
  margin-top: 10px;
  margin-right: 10px;
}

button:hover {
  background-color: #FDAE39;
}

.error-messages {
  color: #ff0000;
  font-weight: bold;
  margin-top: 10px;
}
</style>
