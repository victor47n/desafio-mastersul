import axios from 'axios';

// Cria uma instância do axios com configurações personalizadas
export const api = axios.create({
    baseURL: 'http://localhost:3333/v1',
})