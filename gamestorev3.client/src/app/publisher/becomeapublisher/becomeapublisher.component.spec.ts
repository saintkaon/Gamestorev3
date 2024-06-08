import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BecomeapublisherComponent } from './becomeapublisher.component';

describe('BecomeapublisherComponent', () => {
  let component: BecomeapublisherComponent;
  let fixture: ComponentFixture<BecomeapublisherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BecomeapublisherComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BecomeapublisherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
