import {
  Column,
  Entity,
  JoinColumn,
  JoinTable,
  ManyToMany,
  OneToMany,
  OneToOne,
} from 'typeorm';
import { SoftDeleteEntity } from '@/common/entity/base.soft-delete.entity';
import { StockChange } from './stock.change.entity';
import { StockWarehouse } from './stock.warehouse.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { User } from '@/module/user/entity/user.entity';
import { Shipment } from '@/module/shipment/entity/shipment.entity';

@Entity({ name: 'stock_transfers' })
export class StockTransfer extends SoftDeleteEntity {
  @OneToOne(() => StockWarehouse)
  @JoinColumn()
  public from: StockWarehouse;

  @OneToOne(() => StockWarehouse)
  @JoinColumn()
  public to: StockWarehouse;

  @OneToOne(() => Shipment)
  @JoinColumn()
  public shipment: Shipment;

  @OneToOne(() => User)
  @JoinColumn()
  public sentBy: User;

  @OneToOne(() => User, { nullable: true })
  @JoinColumn()
  public receivedBy!: User;

  @OneToOne(() => User, { nullable: true })
  @JoinColumn()
  public approvedBy!: User;

  @OneToMany(() => StockChange, (stockChange) => stockChange.stockTransfer, {
    nullable: false,
  })
  @JoinColumn()
  public changes: StockChange[];

  @Column({ type: 'text', nullable: true })
  public notes: string;

  @ManyToMany(() => File, { nullable: true })
  @JoinTable({ name: 'stock_transfer_files' })
  public files!: File[];
}
