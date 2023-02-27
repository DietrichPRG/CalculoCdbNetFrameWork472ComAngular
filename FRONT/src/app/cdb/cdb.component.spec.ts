import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';

import { CdbComponent } from './cdb.component';
import { NgxMaskDirective, NgxMaskPipe, provideEnvironmentNgxMask, provideNgxMask } from 'ngx-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 


describe('CdbComponent', () => {
  let component: CdbComponent;
  let fixture: ComponentFixture<CdbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CdbComponent],
      imports: [
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        MatSnackBarModule,
        MatCardModule,
        MatFormFieldModule,
        MatIconModule,
        MatSlideToggleModule,
        MatDividerModule,
        NgxMaskDirective,
        NgxMaskPipe,
        MatInputModule,
        BrowserAnimationsModule
      ],
      providers: [
        provideEnvironmentNgxMask(),
        provideNgxMask(),
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Deve calcular o investimento de R$ 1.000,00 por 12 meses e retornar somente o resultado', async () => {
    component.valorDoInvestimentoFormControl.setValue(1000);
    component.tempoDeInvestimentoFormControl.setValue(12);
    component.mostrarHistorico = false;
    await component.calcular();
    expect(component.dataSource.length).toBe(1);
  });

  it('Deve calcular o investimento de R$ 1.000,00 por 12 meses e retornar o histórico com 12 registros', async () => {
    const qtdDeMeses = 12;

    component.valorDoInvestimentoFormControl.setValue(1000);
    component.tempoDeInvestimentoFormControl.setValue(qtdDeMeses);
    component.mostrarHistorico = true;
    await component.calcular();
    expect(component.dataSource.length).toBe(qtdDeMeses);
  });

  it('Não deve calcular investimento com apenas 1 mes.', async () => {
    const qtdDeMeses = 1;

    component.valorDoInvestimentoFormControl.setValue(1000);
    component.tempoDeInvestimentoFormControl.setValue(qtdDeMeses);
    component.mostrarHistorico = true;
    await component.calcular();
    expect(component.dataSource.length).toBe(0);
  });

  it('Não deve calcular investimento com valor igual a 0', async () => {
    const qtdDeMeses = 2;

    component.valorDoInvestimentoFormControl.setValue(0);
    component.tempoDeInvestimentoFormControl.setValue(qtdDeMeses);
    component.mostrarHistorico = true;
    await component.calcular();
    expect(component.dataSource.length).toBe(0);
  });
});
