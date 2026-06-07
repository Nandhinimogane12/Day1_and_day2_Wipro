import { Component } from '@angular/core';
import { BooksComponent } from './components/books/books';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BooksComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}