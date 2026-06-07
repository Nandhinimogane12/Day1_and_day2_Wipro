import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeComponent } from './employee/employee';
@Component({
  selector: 'app-root',
  imports: [EmployeeComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('EmployeePortal');
}
