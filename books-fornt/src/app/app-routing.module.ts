import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from './pages/book/book.component';

const routes: Routes = [
  { path: 'books', component: BookComponent },
  { path: '', redirectTo: 'books', pathMatch: 'full'},
  { path: '**', redirectTo: 'books', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
