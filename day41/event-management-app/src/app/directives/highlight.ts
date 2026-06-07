import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective implements OnInit {

  @Input() price = 0;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    if (this.price > 2000) {
      this.el.nativeElement.style.backgroundColor = '#FFF8DC';
    }
  }
}