import { SoftDeleteEntity } from '@/common/entity/base.soft-delete.entity';
import { User } from '@/module/user/entity/user.entity';
import { Driver } from './driver.entity';
import { DriverExpensePlan } from './driver.expense-plan.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { Column, Entity, JoinColumn, ManyToOne, OneToOne } from 'typeorm';
import { DriverExpenseType } from '@/module/driver/entity/driver.expense-type.entity';
import { TaskRequest } from '@/module/task/entity/task.request.entity';
import { DriverGroup } from './driver.group.entity';

@Entity({ name: 'driver_expense_requests' })
export class DriverExpenseRequest extends SoftDeleteEntity {
  @OneToOne(() => DriverExpenseType)
  @JoinColumn()
  public type: DriverExpenseType;

  @ManyToOne(() => TaskRequest, (expense) => expense.expenseRequests)
  @JoinColumn()
  public taskRequest: TaskRequest;

  @OneToOne(() => Driver, { nullable: false })
  @JoinColumn()
  public driver: Driver;

  @OneToOne(() => DriverGroup, { nullable: false })
  @JoinColumn()
  public driverGroup: DriverGroup;

  @OneToOne(() => DriverExpensePlan, { nullable: false })
  @JoinColumn()
  public plan: DriverExpensePlan;

  @Column({ type: 'int', default: 0 })
  public amountRequest: number;

  @Column({ type: 'date', nullable: true })
  public timeRequested: Date;

  @Column({ type: 'text', nullable: true })
  public notes: string;

  @Column({ type: 'int', default: 0, nullable: true })
  public amountApproved!: number;

  @Column({ type: 'timestamptz', nullable: true })
  public timeApproved!: Date;

  @Column({ type: 'timestamptz', nullable: true })
  public timeRejected!: Date;

  @OneToOne(() => User)
  @JoinColumn()
  public approvedBy!: User;

  @OneToOne(() => File, { nullable: true })
  @JoinColumn()
  public file!: File;
}
