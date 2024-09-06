import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '@app/_services';

@Component({
  selector: 'app-email-verification',
  templateUrl: './email-verification.component.html'
})
export class EmailVerificationComponent implements OnInit {
  verificationForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Inicializa el formulario reactivo
    this.verificationForm = this.formBuilder.group({
      token0: ['', [Validators.required, Validators.maxLength(1)]],
      token1: ['', [Validators.required, Validators.maxLength(1)]],
      token2: ['', [Validators.required, Validators.maxLength(1)]],
      token3: ['', [Validators.required, Validators.maxLength(1)]]
    });
  }

  onInput(event: any, index: number): void {
    // Avanza automáticamente al siguiente input
    if (event.target.value.length === 1 && index < 4) {
      document.getElementsByTagName('input')[index].focus();
    }
  }

  onSubmit(): void {
    if (this.verificationForm.valid) {
      const tokenString = Object.values(this.verificationForm.value).join('');
      // Llamar al servicio para confirmar el correo
      this.accountService.confirmarCorreo(tokenString)
        .subscribe({
          next: (response) => {
            console.log('Correo confirmado exitosamente:', response);
            this.router.navigate(['/dashboard']);
          },
          error: (error) => {
            console.error('Error al confirmar el correo:', error);
          }
        });
    } else {
      console.log('Formulario inválido');
    }
  }

  resendCode(): void {
    console.log('Código reenviado');
  }
}