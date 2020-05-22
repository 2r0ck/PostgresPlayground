import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GoodsComponent } from './components/goods/goods.component';
import { FormsModule } from '@angular/forms';
import { GoodsDetailComponent } from './components/goods-detail/goods-detail.component';
import { MessageComponent } from './components/message/message.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SearchComponent } from './components/search/search.component'

@NgModule({
  declarations: [
    AppComponent,
    GoodsComponent,
    GoodsDetailComponent,
    MessageComponent,
    DashboardComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
