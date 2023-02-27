import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ICalcularCdbRequest } from '../models/calcularCdbRequest';
import { ICdb } from '../models/cdbModel';
import { CdbService } from '../services/cdb.service';

@Component({
  selector: 'app-cdb',
  templateUrl: './cdb.component.html',
  styleUrls: ['./cdb.component.css']
})
export class CdbComponent {
  title = 'B3FrontAngular';

  mostrarHistorico: boolean = false;

  valorDoInvestimentoFormControl = new FormControl(1, [Validators.required]);
  tempoDeInvestimentoFormControl = new FormControl(2, [Validators.required]);

  displayedColumns: string[] = ['Mes', 'valorInvestido', 'valorAjustado', 'IR', 'ValorIR', 'valorLiquido'];
  dataSource: ICdb[] = [];

  constructor(private _snackBar: MatSnackBar, private _cdbService: CdbService) { }

  calcular = async () => {

    if (!this.validarForms()) {
      this.openSnackBar('Preencha todos os campos', 'Ok');
      return;
    }

    const valorDoInvestimento = this.valorDoInvestimentoFormControl.value;
    const tempoDeInvestimento = this.tempoDeInvestimentoFormControl.value;
    const payLoad = { quantidadeDeMeses: tempoDeInvestimento, valor: valorDoInvestimento } as ICalcularCdbRequest;

    try {
      if (this.mostrarHistorico) {
        const retorno = await this._cdbService.calcularCdbComHistorico(payLoad);

        this.dataSource = retorno;
      }
      else {
        this.dataSource = [await this._cdbService.calcularCdb(payLoad)];
      }
    }
    catch (error: any) {
      this.dataSource = [];

      const msg = error.response.data;
      this.openSnackBar(msg, 'Ok');
    }
  }

  validarForms = () => (this.valorDoInvestimentoFormControl.valid) && this.tempoDeInvestimentoFormControl.valid;

  openSnackBar = (message: string, action: string) => this._snackBar.open(message, action);

}
