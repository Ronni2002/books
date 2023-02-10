import { NgModule } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import { BrowserModule } from '@angular/platform-browser';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookComponent } from './book/book.component';import { ReactiveFormsModule } from '@angular/forms';
import {MatDialogModule} from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BookComponent
  ],
  imports: [
    MatToolbarModule,
    MatCardModule,
    CommonModule,
    MatFormFieldModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    BookComponent,
    MatFormFieldModule,
    MatDialogModule
  ]
})
export class PagesModule { }
