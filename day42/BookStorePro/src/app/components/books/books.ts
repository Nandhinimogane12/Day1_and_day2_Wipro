import {
  Component,
  OnInit,
  OnDestroy
} from '@angular/core';

import {
  CommonModule
} from '@angular/common';

import {
  Observable,
  Subscription
} from 'rxjs';

import { DataService } from '../../services/data.service';
import { BookCardComponent } from '../book-card/book-card';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [
    CommonModule,
    BookCardComponent
  ],
  templateUrl: './books.html',
  styleUrl: './books.css'
})
export class BooksComponent
implements OnInit, OnDestroy {

  books: any[] = [];

  books$!: Observable<any[]>;

  subscription!: Subscription;

  constructor(
    private dataService: DataService
  ) {}

  ngOnInit() {

    this.subscription =
  this.dataService.getBooks()
  .subscribe(data => {
    console.log(data);
    this.books = data;
  });

    this.books$ =
      this.dataService.getBooks();
  }

  ngOnDestroy() {

    if (this.subscription) {
      this.subscription.unsubscribe();
    }

  }
}