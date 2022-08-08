import { Entity, ManyToOne, OneToOne, JoinColumn, Column } from 'typeorm';
import { TagEntity } from '@/common/entity/base.tag.entity';
import { RouteCost } from '@/module/route/entity/route.cost.entity';
import { User } from '@/module/user/entity/user.entity';

@Entity({ name: 'route_cost_items' })
export class RouteCostItem extends TagEntity {
  public approved: boolean;

  @ManyToOne(() => RouteCost, (route) => route.costItems)
  @JoinColumn()
  public cost: RouteCost;

  @Column({ nullable: true })
  public costId!: string;

  @OneToOne(() => User)
  @JoinColumn()
  public approvedBy: User;

  @Column({ nullable: true })
  public approvedById!: string;

  @Column({
    type: 'timestamptz',
    nullable: false,
  })
  public timeApproved: Date;

  @Column({ type: 'int', nullable: false })
  public value: number;

  @OneToOne(() => RouteCostItem)
  @JoinColumn()
  public previous: RouteCostItem;

  @Column({ nullable: true })
  public previousId!: string;

  @Column({ type: 'int', nullable: false })
  public costPercentage: number;
}
