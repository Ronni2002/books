import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {

  books: Book[] = [];
  bookDetails: Book[] = [];
  formCreate!: FormGroup;
  formUpdate!: FormGroup;
  setterCreate = {};
  setterUpdate!: Book;
  book!: Book;

  constructor(private bookService: BookService, private _fb: FormBuilder) { }

  ngOnInit(): void {
    this.loadBoks();
    this.buildCreateForm();
    this.buildUpdateForm();
  }

  buildCreateForm() {
    this.formCreate = this._fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      excerpt: ['', Validators.required],
      pageCount: ['', Validators.required],
    });
  }

  buildUpdateForm() {
    this.formUpdate = this._fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      excerpt: ['', Validators.required],
      pageCount: ['', Validators.required],
    });
  }

  loadBoks() {
    this.bookService.getAll().subscribe((books: Book[]) => {
      this.books = books;
      console.log(this.books);
    })
  }

  getBookById(id: number){
    this.bookDetails = [];
    this.bookService.getById(id).subscribe((getBook: Book) => {
      this.bookDetails.push(getBook);
      console.log(this.bookDetails);
    })
  }

  updateBook(id: number){

    this.bookService.update(id, this.formUpdate.value).subscribe(data => {
      console.log(data);
    })
    
  }

  createBook(){
    this.bookService.create(this.formCreate.value).subscribe(data => {
      console.log(data);
    })
  }

  deleteBook(id: number){
    this.bookService.delete(id).subscribe((deletedBook: Book) => {
      console.log(deletedBook);
    })
  }

}
