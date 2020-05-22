import { Component, OnInit, Input } from '@angular/core';
import { Good } from 'src/app/models/good';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { GoodService } from 'src/app/services/good.service';

@Component({
  selector: 'app-goods-detail',
  templateUrl: './goods-detail.component.html',
  styleUrls: ['./goods-detail.component.scss']
})
export class GoodsDetailComponent implements OnInit {

  good: Good;
  constructor(private route: ActivatedRoute,
    private goodsService: GoodService,
    private location: Location) { }

  ngOnInit(): void {
    this.getGood();
  }


  getGood(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.goodsService.getGood(id)
      .subscribe(g => this.good = g);
  }

  goBack(): void {
    this.location.back();
  }
  save(): void {
    this.goodsService.addOrUpdate(this.good)
      .subscribe(() => this.goBack());
  }


}
