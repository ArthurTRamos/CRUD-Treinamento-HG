import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactBox } from './contact-box';

describe('ContactBox', () => {
  let component: ContactBox;
  let fixture: ComponentFixture<ContactBox>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContactBox],
    }).compileComponents();

    fixture = TestBed.createComponent(ContactBox);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
