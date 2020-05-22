import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Good } from 'src/app/models/good';
import { GoodService } from 'src/app/services/good.service';
import { Subject } from 'rxjs/internal/Subject';
import { debounceTime, switchMap, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  goods$: Observable<Good[]>;
  private searchTerms = new Subject<string>();
  constructor(private gService: GoodService) { }

  ngOnInit(): void {

    this.goods$ = this.searchTerms.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((x: string) => this.gService.search(x)));
  }

  search(trem: string) {
    this.searchTerms.next(trem);
  }

}
