import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopDetailsFormComponent } from './shop-details-form.component';

describe('ShopDetailsFormComponent', () => {
  let component: ShopDetailsFormComponent;
  let fixture: ComponentFixture<ShopDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopDetailsFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShopDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
