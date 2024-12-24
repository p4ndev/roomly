import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomUnlockComponent } from './room-unlock.component';

describe('RoomUnlockComponent', () => {
  let component: RoomUnlockComponent;
  let fixture: ComponentFixture<RoomUnlockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RoomUnlockComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoomUnlockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
