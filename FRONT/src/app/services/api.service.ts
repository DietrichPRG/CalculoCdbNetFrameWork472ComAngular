import { Injectable } from '@angular/core';
import axios, { AxiosInstance } from "axios";

const baseUrl = 'https://localhost:44312/api';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private headers = {
    "Accept": "application/json",
    "Content-Type": "application/json",
  };

  private axiosClient: AxiosInstance;

  constructor() {
    this.axiosClient = axios.create({
      timeout: 3000,
      headers: this.headers,
    });
  }

  public async get<T>(url: string): Promise<T> {
    try {
      return await this.axiosClient.get<T, any>(baseUrl + url, {
        headers: this.headers
      }).then((response) => response.data as T);

    } catch (error) { return Promise.reject(error); }
  }

  public async post<T>(url: string, obj: object): Promise<T> {

    try {
      return await this.axiosClient.post<T, any>(baseUrl + url, obj, {
        headers: this.headers
      }).then((response) => response.data as T);
    } catch (error) { return Promise.reject(error); }

  }

  // generete put method
  public async put<T>(url: string, id: string, obj: object): Promise<T> {

    try {
      return await this.axiosClient.put<T, any>(baseUrl + url + '/' + id, obj, {
        headers: this.headers
      }).then((response) => response.data as T);
    } catch (error) { return Promise.reject(error); }

  }

  // generete delete method
  public async delete<T>(url: string, id: string): Promise<T> {
    try {
      return await this.axiosClient.delete<T, any>(baseUrl + url + '/' + id, {
        headers: this.headers
      }).then((response) => response.data as T);
    } catch (error) { return Promise.reject(error); }
  }
}
