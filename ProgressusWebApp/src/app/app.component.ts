import { Component } from '@angular/core';

import { AccountService } from './_services';
import { Account, Role } from './_models';

declare var bootstrap: any;

@Component({ selector: 'app-root', templateUrl: 'app.component.html' })
export class AppComponent {
    Role = Role;
    account?: Account | null;

    constructor(private accountService: AccountService) {
        this.accountService.account.subscribe(x => this.account = x);
    }

    confirmLogout() {
        this.accountService.logout();
        // Aquí puedes también cerrar el modal si no se cierra automáticamente
        const modalElement = document.getElementById('logoutModal');
        if (modalElement) {
            const modalBootstrap = bootstrap.Modal.getInstance(modalElement); // Obtén la instancia del modal
            modalBootstrap?.hide(); // Cierra el modal
        }
    }
}