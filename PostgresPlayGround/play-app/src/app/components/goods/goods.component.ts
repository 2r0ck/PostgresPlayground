import { Component, OnInit } from '@angular/core';
import { Good } from 'src/app/models/good';
import { GoodService } from 'src/app/services/good.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-goods',
  templateUrl: './goods.component.html',
  styleUrls: ['./goods.component.scss']
})
export class GoodsComponent implements OnInit {

  goods: Good[];

  constructor(private messageService: MessageService, private gservice: GoodService) { }

  ngOnInit(): void {
    this.getGoods();
  }

  getGoods() {
    this.gservice.getGoods().subscribe(goodsObserver => {
      this.goods = goodsObserver;
    })
  }

  add(name: string) {
    var newGood = { name } as Good;
    this.gservice.addOrUpdate(newGood).subscribe(goodsObserver => {
      this.getGoods();
    })
  }

  delete(g: Good) {

    this.gservice.delete(g).subscribe(goodsObserver => {
      this.getGoods();
    })
  }
}
