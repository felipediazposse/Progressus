import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-verificacion-modal',
  templateUrl: 'app-verificacion-modal.html',
  styleUrls:['./app-verificacion-modal.scss']
})
export class VerificacionModalComponent {
    verificacionForm: FormGroup;
    submitted = false;

    constructor(
        public dialogRef: MatDialogRef<VerificacionModalComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private formBuilder: FormBuilder
    ) {
        this.verificacionForm = this.formBuilder.group({
            codigo: ['', [Validators.required, Validators.pattern('^[0-9]{4}$')]] // 4 dígitos numéricos
        });
    }

    // Método para enviar el formulario
    onSubmit() {
        this.submitted = true;

        if (this.verificacionForm.invalid) {
            return;
        }

        // Devolvemos el código al componente que abrió el modal
        this.dialogRef.close(this.verificacionForm.value.codigo);
    }
}
