import axios from "axios"
import { BASE_URL } from "./constants"

const config = {
    headers: {
        "Content-Type": "application/json",
        "Accept": "application/json"
    },
    withCredentials: true
}

export const callAPI = async (resource) => {
    const { data } = await axios.get(`${BASE_URL}/${resource}`, config);
    return data;
}


export const checkUser = async () => {
    const { data } = await axios.get("http://localhost:5128/api/auth/checkAuth", config);
    return data;
}


export const userLogin = async ({ email, password }) => {
    var res = await axios.post("http://localhost:5128/api/auth/login", { email, password }, {
        withCredentials: true
    });
    return res;
}

export const userRegister = async ({ email, password }) => {
    var res = axios.post("http://localhost:5128/api/auth/register", { email, password });
    return res;
}

export const userLogout = async () => {
    const { data } = await axios.post("http://localhost:5128/api/auth/logout",{},{withCredentials:true});
    return data;
}