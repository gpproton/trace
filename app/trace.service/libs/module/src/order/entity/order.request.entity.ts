import {
  Column,
  Entity,
  Generated,
  JoinColumn,
  OneToMany,
  OneToOne,
} from 'typeorm';
import { SoftDeleteEntity } from '@/common/entity/base.soft-delete.entity';
import { Customer } from '@/module/customer/entity/customer.entity';
import { Task } from '@/module/task/entity/task.entity';
import { Ticket } from '@/module/ticket/entity/ticket.entity';
import { User } from '@/module/user/entity/user.entity';
import { OrderFreight } from './order.freight.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { Order } from './order.entity';

export enum OrderRequestStatus {
  PENDING = 'pending',
  APPROVED = 'approved',
  CANCELLED = 'cancelled',
}

@Entity({ name: 'order_requests' })
export class OrderRequest extends SoftDeleteEntity {
  @Generated()
  @Column({ unique: true })
  public identifier: number;

  @OneToOne(() => Order, (order) => order.request, { nullable: true })
  @JoinColumn()
  public order!: Order;

  @OneToOne(() => Task, (task) => task.orderRequest, { nullable: false })
  @JoinColumn()
  public task: Task;

  @Column({
    type: 'enum',
    enum: OrderRequestStatus,
    default: OrderRequestStatus.PENDING,
  })
  public status: OrderRequestStatus;

  @Column({ default: false })
  public verifyOTP: boolean;

  @Column({ default: false })
  public autoZoneOTP: boolean;

  @Column({ default: false })
  public autoInvoice: boolean;

  @OneToOne(() => Customer, { nullable: false })
  @JoinColumn()
  public customer: Customer;

  @OneToOne(() => User, { nullable: true })
  @JoinColumn()
  public approvedBy!: User;

  @Column({ type: 'timestamptz', nullable: true })
  public approvedAt!: Date;

  @OneToMany(() => OrderFreight, (freight) => freight.orderRequest, {
    nullable: true,
  })
  @JoinColumn()
  public freights!: OrderFreight[];

  @OneToOne(() => File, { nullable: true })
  @JoinColumn()
  public file!: File;

  @OneToMany(() => Ticket, (ticket) => ticket.orderRequest)
  @JoinColumn()
  public tickets!: Ticket[];
}
