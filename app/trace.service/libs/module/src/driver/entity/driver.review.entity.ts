import {
  Column,
  Entity,
  JoinColumn,
  JoinTable,
  ManyToMany,
  OneToOne,
} from 'typeorm';
import { TagEntity } from '@/common/entity/base.tag.entity';
import { User } from '@/module/user/entity/user.entity';
import { Driver } from './driver.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { DriverReviewComment } from './driver.review.comment.entity';
import { DriverReviewType } from './driver.review.type.entity';

@Entity({ name: 'driver_reviews' })
export class DriverReview extends TagEntity {
  @OneToOne(() => Driver)
  @JoinColumn()
  public driver: Driver;

  @OneToOne(() => User)
  @JoinColumn()
  public reviewBy!: User;

  @Column({ type: 'timestamptz', nullable: true })
  public approvedAt!: Date;

  @OneToOne(() => User, { nullable: true })
  @JoinColumn()
  public approvedBy!: User;

  @Column({ type: 'timestamptz', nullable: true })
  public started: Date;

  @Column({ type: 'timestamptz', nullable: true })
  public ended: Date;

  @Column()
  public passed: boolean;

  @OneToOne(() => DriverReviewType)
  @JoinColumn()
  public type: DriverReviewType;

  @Column({ type: 'int', default: 1 })
  public pointScored: number;

  @ManyToMany(() => DriverReviewComment)
  @JoinTable({ name: 'drv_rvw_link_comments' })
  public comments!: DriverReviewComment[];

  @ManyToMany(() => File, { nullable: true })
  @JoinTable({ name: 'driver_review_files' })
  public files!: File[];

  @Column({ type: 'text', nullable: true })
  public remarks!: string;
}
