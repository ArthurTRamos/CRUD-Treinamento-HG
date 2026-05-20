import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUpdatePage } from './create-update-page';

describe('CreateUpdatePage', () => {
  let component: CreateUpdatePage;
  let fixture: ComponentFixture<CreateUpdatePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateUpdatePage],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateUpdatePage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
