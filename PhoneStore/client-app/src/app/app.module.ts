import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';;
import { PhoneDetailComponent } from './phone-detail/phone-detail.component'
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    { path: 'detail/:id', component: PhoneDetailComponent },
];
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(routes)],
    exports: [RouterModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }