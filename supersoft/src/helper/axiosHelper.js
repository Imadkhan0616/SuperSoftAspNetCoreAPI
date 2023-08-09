import React from "react";
import axios from "axios";

export const getAsync = async (url, requestHeaders) => {
    let headers = mergeHeaders(requestHeaders, url);
    const response = await axios.get(`https://localhost:7101/api/${url}`, {headers});
    return response.data;
}

export const postAsync = async (url, requestBody, requestHeaders = null) =>{
    let headers = mergeHeaders(requestHeaders, url);
    console.log(requestBody);
    const response = await axios.post(`https://localhost:7101/api/${url}`, requestBody,{headers});
    return response.data;
}

export const putAsync = async (url, requestBody, requestHeaders = null) => {
    let headers = mergeHeaders(requestHeaders, url);
    console.log(requestBody);
    const response = await axios.put(`https://localhost:7101/api/${url}`, requestBody,{headers});
    return response.data;
}

export const deleteAsync = async(url, requestBody, requestHeaders = null) => {
    let headers = mergeHeaders(requestHeaders, url);
    const data = requestBody;
    const response = await axios.delete(`https://localhost:7101/api/${url}`,{
        headers,
        data
    });
    return response.data;
}