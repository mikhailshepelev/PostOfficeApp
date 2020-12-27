import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LettersbagComponent } from './lettersbag.component';

describe('LettersbagComponent', () => {
  let component: LettersbagComponent;
  let fixture: ComponentFixture<LettersbagComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LettersbagComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LettersbagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
