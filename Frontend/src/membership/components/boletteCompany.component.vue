<script>
import JsPDF from 'jspdf';
import ToolbarBolette from "@/public/components/toolbarBolette.component.vue";

export default {
  name: 'boletteCompany',
  components: { ToolbarBolette },
  props: {
    nombreEmpresa: String,
    ruc: Number,
    direction: String,
    tipoTarjeta: String,
  },
  data() {
    return {
      tipoMembresia: null,
    };
  },
  created() {
    this.tipoMembresia = this.$route.query.tipoMembresia;
  },
  methods: {
    descargarBoleta() {
      const doc = new JsPDF();

      const estiloTitulo = { fontSize: 18, fontStyle: 'bold', marginBottom: 10 };
      const estiloContenido = { fontSize: 14, marginBottom: 5 };

      doc.text('Boleta de Compra', 20, 20);
      doc.text('Nombre de Empresa:', 20, 40);
      doc.text(this.nombreEmpresa, 80, 40, estiloContenido);
      doc.text('RUC:', 20, 60);
      doc.text(this.ruc.toString(), 70, 60, estiloContenido);
      doc.text('Dirección:', 20, 80);
      doc.text(this.direction, 70, 80, estiloContenido);
      doc.text('Tipo de Tarjeta:', 20, 100);
      doc.text(this.tipoTarjeta, 70, 100, estiloContenido);
      doc.text('Precio de Membresía:', 20, 120);
      doc.text(this.tipoMembresia, 80, 120, estiloContenido);

      doc.save('boleta_compra.pdf');
    }
  },
};
</script>

<template>
  <div>
    <toolbarBoleta></toolbarBoleta>
  </div>

  <div>
    <h2>Boleta de Compra</h2>
    <div class="boleta">
      <img src="https://github.com/LuceroObispoRios/Grupo1_WS52/blob/main/Proyecto/image/Cargalogo.png?raw=true" alt="Imagen" style="height: 200px"><br><br>
      <table class="info">
        <tr>
          <td><strong>Nombre de la Empresa:</strong></td>
          <td>{{ nombreEmpresa }}</td>
        </tr>
        <tr>
          <td><strong>RUC:</strong></td>
          <td>{{ ruc }}</td>
        </tr>
        <tr>
          <td><strong>Dirección:</strong></td>
          <td>{{ direction }}</td>
        </tr>
        <tr>
          <td><strong>Tipo de Tarjeta:</strong></td>
          <td>{{ tipoTarjeta }}</td>
        </tr>
        <tr>
          <td><strong>Precio de Membresía:</strong></td>
          <td>{{ tipoMembresia }}</td>
        </tr>
      </table>
      <button @click="descargarBoleta">Descargar Boleta</button>
    </div>
  </div>
  <br>
</template>

<style scoped>
h2 {
  color: #181818;
  font-size: 24px;
  text-align: center;
}

.boleta {
  text-align: center;
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  margin: 20px auto;
  max-width: 400px;
}

.info {
  width: 100%;
}

.info td {
  padding: 10px;
  border-bottom: 1px solid #ccc;
  text-align: left;
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
  display: block;
  margin-left: auto;
  margin-right: auto;
}

button:hover {
  background-color: #ee8f00;
}
</style>
