import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

interface Turno {
  dia: string;
  hora: string;
  estudiantes: string[];
  maxCapacity: number;
  confirmado?: boolean; // Añadimos un estado de confirmación
}

@Component({
  selector: 'app-turnos',
  templateUrl: './turnos.component.html',
  styleUrls: ['./turnos.component.scss']
})
export class TurnosComponent implements OnInit {
  dias: string[] = ['Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes'];
  diaSeleccionado: string = '';
  usuario: string = 'UsuarioActual'; // Simula el usuario actual

  turnos: Turno[] = [];
  misTurnos: Turno[] = [];
  mostrarConfirmar: boolean = false;
  enMenuPrincipal: boolean = true; // Para saber si estamos en el menú principal

  constructor(private router: Router) {}

  generarTurnos() {
    const horas = [
      '07:00 AM', '08:00 AM', '09:00 AM', '10:00 AM', '11:00 AM', '12:00 PM', '01:00 PM', '02:00 PM',
      '03:00 PM', '04:00 PM', '05:00 PM', '06:00 PM', '07:00 PM', '08:00 PM', '09:00 PM', '10:00 PM'
    ];

    for (let dia of this.dias) {
      for (let hora of horas) {
        this.turnos.push({
          dia: dia,
          hora: hora,
          estudiantes: [],
          maxCapacity: 20
        });
      }
    }
  }

  getTurnosPorDia(dia: string): Turno[] {
    return this.turnos.filter(turno => turno.dia === dia && !turno.confirmado); // Excluye turnos confirmados
  }

  reservarTurno(turno: Turno) {
    if (turno.estudiantes.length < turno.maxCapacity) {
      turno.estudiantes.push(this.usuario);
      this.misTurnos.push(turno);
      this.mostrarConfirmar = true;
      this.enMenuPrincipal = false; // No estamos en el menú principal cuando reservamos
    }
  }

  cancelarReserva(turno: Turno) {
    turno.estudiantes = turno.estudiantes.filter(e => e !== this.usuario);
    this.misTurnos = this.misTurnos.filter(t => t !== turno);
  }

  confirmarTurnos() {
    this.misTurnos.forEach(turno => {
      const turnoExistente = this.turnos.find(t => t.dia === turno.dia && t.hora === turno.hora);
      if (turnoExistente) {
        turnoExistente.estudiantes = turno.estudiantes;
        turnoExistente.confirmado = true; // Marca el turno como confirmado
      }
    });
    this.misTurnos = [];
    this.mostrarConfirmar = false;
    alert("Turnos confirmados correctamente.");
    // No navegamos a ninguna otra página, mantenemos al usuario en la vista actual
  }

  volverAlMenu() {
    if (this.enMenuPrincipal) {
      this.router.navigate(['/login']); // Navegar al login si estamos en el menú principal
    } else {
      this.diaSeleccionado = ''; // Reseteamos la selección del día
      this.enMenuPrincipal = true; // Volvemos al menú principal
    }
  }

  ngOnInit() {
    this.generarTurnos();
  }
}
