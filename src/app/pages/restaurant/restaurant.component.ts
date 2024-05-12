import { Component, OnInit, Input, Output, EventEmitter, ViewEncapsulation  } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrl: './restaurant.component.scss'
})
export class RestaurantComponent {
  public currentRating: number = 0;
  @Input('rating') private rating: number = 0;  // Default rating
  @Input('starCount') public starCount: number = 5;  // Total number of stars
  @Input('color') public color: string = 'accent';  // Color for active stars
  @Output() private ratingUpdated = new EventEmitter<number>();  // Emits the selected rating

  public ratingArr: number[] = [];  // Array to hold the stars for ngFor

  constructor(private snackBar: MatSnackBar) { }
    ngOnInit() {
        this.initializeStars();
    }

    // Initializes the stars based on starCount
    private initializeStars(): void {
        this.ratingArr = Array.from({ length: this.starCount }, (_, index) => index);
        console.log(`Initialized ${this.starCount} stars.`);
    }

    // Handles click on star, updates the rating, and shows a snack bar
    onClick(rating: number): boolean {
        this.rating = rating;
        this.snackBar.open(`You rated ${rating} / ${this.starCount}`, '', {
            duration: 2000  // Can use the class property if it needs to be configurable
        });
        this.ratingUpdated.emit(this.rating);  // Emit the new rating value
        return false;  // Prevent default form submission behavior if needed
    }

    // Determines which icon to show based on the current rating
    showIcon(index: number): string {
        return this.rating >= index + 1 ? 'star' : 'star_border';
    }

    // Optional: Format label for display, useful in other parts of the component if needed
    formatLabel(value: number): string {
        return value >= 1000 ? `${Math.round(value / 1000)}k` : `${value}`;
    }
}

// Enum for defining possible color choices for the stars
export enum StarRatingColor {
    primary = "primary",
    accent = "accent",
    warn = "warn"
}
