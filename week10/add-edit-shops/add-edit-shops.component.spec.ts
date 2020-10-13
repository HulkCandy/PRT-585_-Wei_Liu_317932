import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditShopsComponent } from './add-edit-shops.component';

describe('AddEditShopsComponent', () => {
  let component: AddEditShopsComponent;
  let fixture: ComponentFixture<AddEditShopsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditShopsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditShopsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
