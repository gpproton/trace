import { Entity, Column } from 'typeorm';
import { SoftDeleteEntity } from '@/common/entity';

@Entity({ name: 'drv_review_comments' })
export class DriverReviewComment extends SoftDeleteEntity {
  @Column({ type: 'text', nullable: true })
  public message!: string;
}
