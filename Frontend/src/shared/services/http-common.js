import axios from 'axios';

export default axios.create({
    baseURL: 'https://web-cargasinestres-grupo1.azurewebsites.net',
    headers: {'Content-type': 'application/json' }
});
