import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog'; // Importar MatDialog
import { AccountService, AlertService } from '@app/_services'; // Importar los servicios necesarios
import { MustMatch } from '@app/_helpers'; // Importar el validador personalizado
import { VerificacionModalComponent } from './app-verificacion-modal.component'; // Importar el componente del modal

@Component({
    templateUrl: 'register.component.html',
    styleUrls: ['register.component.scss']
})
export class RegisterComponent implements OnInit {
    form!: FormGroup;
    submitting = false;
    submitted = false;
    email!: string; // Variable para almacenar el email

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private accountService: AccountService,
        private alertService: AlertService,
        private dialog: MatDialog // Inyectamos MatDialog para manejar modales
    ) { }

    ngOnInit() {
        // Inicializamos el formulario con validaciones
        this.form = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
            confirmPassword: ['', Validators.required],
            acceptTerms: [false, Validators.requiredTrue]
        }, {
            validator: MustMatch('password', 'confirmPassword') // Validador personalizado
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    async onSubmit() {
        this.submitted = true;
        this.alertService.clear(); // Limpiamos alertas al enviar

        // Si el formulario es inválido, detenemos el proceso
        if (this.form.invalid) {
            return;
        }

        // Si ya se está enviando el formulario, no hacemos nada
        if (this.submitting) return; 
        this.submitting = true;

        try {
            // Guardamos el email
            
            this.email = this.f.email.value;

            // Registramos al usuario y esperamos a que se complete la solicitud
            await this.accountService.register(this.email, this.f.password.value).toPromise();

            // Registro exitoso, mostramos el modal de verificación
            this.alertService.success('Registro exitoso. Ingrese el código de verificación.', { keepAfterRouteChange: true });
            this.abrirModalVerificacion();
        } catch (error) {
            // Si hay un error, mostramos el mensaje correspondiente
            this.alertService.error('Ya existe un usuario con ese email en uso.');
        } finally {
            this.submitting = false; // Reseteamos el estado de envío
        }
          // Registro exitoso, mostramos el modal de verificación
          this.alertService.success('Registro exitoso. Ingrese el código de verificación.', { keepAfterRouteChange: true });
          this.abrirModalVerificacion();
    }

    abrirModalVerificacion() {
        // Abrimos el modal con el email pasado como dato
        const dialogRef = this.dialog.open(VerificacionModalComponent, {
            width: '300px',
            data: { email: this.email }
        });

        // Al cerrar el modal, verificamos el código ingresado
        dialogRef.afterClosed().subscribe(async (result) => {
            if (result) {
                await this.verificarCodigo(result); // Si el usuario ingresó el código, lo verificamos
            } else {
                this.alertService.error('El código de verificación es requerido.'); // Si no, mostramos un error
            }
        });
    }

    async verificarCodigo(codigo: string) {
        try {
            // Verificamos el código ingresado
            await this.accountService.confirmarCorreo(this.email, codigo).toPromise();
            // Si es exitoso, mostramos el mensaje de éxito y redirigimos al login
            this.alertService.success('Correo verificado exitosamente.', { keepAfterRouteChange: true });
            this.router.navigate(['../login'], { relativeTo: this.route });
        } catch (error) {
            // Si hay un error al verificar, mostramos un mensaje de error
            this.alertService.error('Error al verificar el correo.');
        }
    }
}
