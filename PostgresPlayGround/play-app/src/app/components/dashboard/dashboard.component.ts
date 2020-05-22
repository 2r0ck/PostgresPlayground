import { Component, OnInit } from '@angular/core';
import { Good } from 'src/app/models/good';
import { GoodService } from 'src/app/services/good.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  goods: Good[];
  constructor(private goodsService: GoodService) { }

  ngOnInit(): void {
    this.getGoods();
  }

  getGoods() {
    this.goodsService.getGoods().subscribe(g => this.goods = g.slice(1, 5));
  }

}
