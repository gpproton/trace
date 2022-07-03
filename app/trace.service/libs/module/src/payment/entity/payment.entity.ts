import {
  Column,
  Entity,
  OneToOne,
  ManyToMany,
  JoinTable,
  JoinColumn,
} from 'typeorm';
import { TagEntity } from '@/common/entity/base.tag.entity';
import { User } from '@/module/user/entity/user.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { TransactionAccount } from './payment.transcation-account.entity';
import { PaymentType } from './payment.type.entity';
import { PaymentLoan } from './payment.loan.entity';
import { PaymentRequest } from './payment.request.entity';
import { PaymentRequestStatus, PayTransactionType } from '@/common/entity';

@Entity({ name: 'payments' })
export class Payment extends TagEntity {
  @OneToOne(() => PaymentType)
  public type: PaymentType;

  @Column({
    type: 'enum',
    enum: PayTransactionType,
    default: PayTransactionType.PAYMENT,
    nullable: false,
  })
  public transactionType: PayTransactionType;

  @Column({
    type: 'enum',
    enum: PaymentRequestStatus,
    default: PaymentRequestStatus.PENDING,
    nullable: false,
  })
  public status: PaymentRequestStatus;

  @OneToOne(() => TransactionAccount)
  @JoinColumn()
  public sourceAccount: TransactionAccount;

  @OneToOne(() => TransactionAccount)
  @JoinColumn()
  public targetAccount: TransactionAccount;

  @Column({ type: 'int', default: 0 })
  public amount: number;

  @ManyToMany(() => User, { nullable: true })
  @JoinTable({ name: 'payment_users' })
  public involvedParties!: User[];

  @OneToOne(() => User, { nullable: true })
  @JoinColumn()
  public approvedBy!: User;

  @Column({
    type: 'timestamptz',
    nullable: true,
  })
  public approvedTime!: Date;

  @Column({
    type: 'timestamptz',
    nullable: true,
  })
  public paymentTime!: Date;

  @OneToOne(() => PaymentLoan, { nullable: true })
  @JoinColumn()
  public loan!: PaymentLoan;

  @OneToOne(() => PaymentRequest, { nullable: true })
  @JoinColumn()
  public request!: PaymentRequest;

  @ManyToMany(() => File)
  @JoinTable({ name: 'payment_files' })
  public files!: File[];
}
