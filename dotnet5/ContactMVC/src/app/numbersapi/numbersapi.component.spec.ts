import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NumbersapiComponent } from './numbersapi.component';

describe('NumbersapiComponent', () => {
  let component: NumbersapiComponent;
  let fixture: ComponentFixture<NumbersapiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NumbersapiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NumbersapiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
