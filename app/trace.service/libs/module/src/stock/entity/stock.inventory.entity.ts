import {
  Column,
  Entity,
  Generated,
  JoinColumn,
  JoinTable,
  ManyToMany,
  ManyToOne,
  OneToOne,
} from 'typeorm';
import { SoftDeleteEntity } from '@/common/entity/base.soft-delete.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { StockWarehouse } from './stock.warehouse.entity';
import { ProductModel } from '@/module/product/entity/product.model.entity';

@Entity({ name: 'stock_inventory' })
export class StockInventory extends SoftDeleteEntity {
  @Generated()
  @Column({ unique: true })
  public identifier: number;

  @Column({ type: 'varchar', default: 128 })
  public barcode: string;

  @OneToOne(() => ProductModel)
  @JoinColumn()
  public product: ProductModel;

  @ManyToOne(() => StockWarehouse, (warehouse) => warehouse.inventories)
  @JoinColumn()
  public warehouse: StockWarehouse;

  @Column({ type: 'int', default: 1 })
  public totalQuantity: number;

  @Column({ type: 'varchar', default: 1024, nullable: true })
  public notes!: string;

  @ManyToMany(() => File, { nullable: true })
  @JoinTable({ name: 'stock_inventory_files' })
  public files!: File[];
}
