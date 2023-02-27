import { Injectable } from '@angular/core';
import { ICalcularCdbRequest } from '../models/calcularCdbRequest';
import { ICdb } from '../models/cdbModel';
import { ApiService } from './api.service';

const url = '/cdb';

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private api : ApiService) { }

  calcularCdb = async (data : ICalcularCdbRequest) : Promise<ICdb> => {
    return await this.api.post<ICdb>(url, data);
  }

  calcularCdbComHistorico = async (data : ICalcularCdbRequest) : Promise<ICdb[]> => {
    const historico = '/com-historico';
    return await this.api.post<ICdb[]>(url + historico, data);
  }

}
