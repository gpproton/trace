import {
  Column,
  Entity,
  JoinColumn,
  JoinTable,
  ManyToMany,
  OneToOne,
} from 'typeorm';
import { TagEntity } from '@/common/entity/base.tag.entity';
import { ProductBrand } from '@/module/product/entity/product.brand.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { AssetType } from './asset.type.entity';

@Entity({ name: 'assets' })
export class Asset extends TagEntity {
  @Column({ type: 'varchar', length: 128, nullable: false })
  public name: string;

  @OneToOne(() => AssetType)
  @JoinColumn()
  public type: AssetType;

  @Column({ type: 'varchar', length: 128, nullable: true })
  public barcode: string;

  @Column({ type: 'varchar', length: 128, nullable: true })
  public uniqueId: string;

  @Column({ type: 'varchar', length: 32, nullable: true })
  public color: string;

  @OneToOne(() => File, { nullable: true })
  @JoinColumn()
  public picture!: File;

  @OneToOne(() => ProductBrand, { nullable: false })
  @JoinColumn()
  public manufacturer: ProductBrand;

  @Column({ type: 'int', nullable: true, default: 1999 })
  public yearManufactured: number;

  @Column({ type: 'timestamptz', nullable: true })
  public deployed!: Date;

  @Column({ type: 'timestamptz', nullable: true })
  public decommissioned!: Date;

  @ManyToMany(() => File, { nullable: true })
  @JoinTable({ name: 'asset_files' })
  public files!: File[];
}
