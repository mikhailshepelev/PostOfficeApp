import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParcelsbagComponent } from './parcelsbag.component';

describe('ParcelsbagComponent', () => {
  let component: ParcelsbagComponent;
  let fixture: ComponentFixture<ParcelsbagComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParcelsbagComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParcelsbagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
