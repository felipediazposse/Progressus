import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { LayoutComponent } from './layout.component';
import { LoginComponent } from './login.component';
import { RegisterComponent } from './register.component';
import { VerifyEmailComponent } from './verify-email.component';
import { ForgotPasswordComponent } from './forgot-password.component';
import { ResetPasswordComponent } from './reset-password.component';
//import { EmailVerificationComponent } from './email-verification.component';
import {MatIconModule} from '@angular/material/icon'
import { MatDialogModule } from '@angular/material/dialog'; // Importar MatDialogModule
import { VerificacionModalComponent } from './app-verificacion-modal.component';

import { MatFormFieldModule } from '@angular/material/form-field';  // Para mat-form-field
import { MatInputModule } from '@angular/material/input';            // Para matInput
import { MatButtonModule } from '@angular/material/button';          // Para mat-button



@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AccountRoutingModule,
        MatIconModule,
        FormsModule,
        MatFormFieldModule,   // Agregar el módulo
        MatInputModule,       // Agregar el módulo
        MatButtonModule,      // Agregar el módulo
        MatDialogModule       // Agregar el módulo para el modal
    ],
    declarations: [
        LayoutComponent,
        LoginComponent,
        RegisterComponent,
        VerifyEmailComponent,
        ForgotPasswordComponent,
        ResetPasswordComponent,
     //   EmailVerificationComponent,
        VerificacionModalComponent
    ]
})
export class AccountModule { }