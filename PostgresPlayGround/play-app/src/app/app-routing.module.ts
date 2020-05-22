import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GoodsComponent } from './components/goods/goods.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { GoodsDetailComponent } from './components/goods-detail/goods-detail.component';


const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'goods', component: GoodsComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'detail/:id', component: GoodsDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
