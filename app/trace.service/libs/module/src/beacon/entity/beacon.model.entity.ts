import { Column, Entity, JoinColumn, OneToOne } from 'typeorm';
import { TypeEntity } from '@/common/entity/base.type.entity';
import { BeaconDeviceProtocol } from './beacon.protocol.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { ProductBrand } from '@/module/product/entity/product.brand.entity';

@Entity({ name: 'beacon_device_models' })
export class BeaconDeviceModel extends TypeEntity {
  @Column({ type: 'varchar', length: 25, nullable: true })
  public version: string;

  @OneToOne(() => ProductBrand)
  @JoinColumn()
  public manufacturer: ProductBrand;

  @OneToOne(() => BeaconDeviceProtocol)
  @JoinColumn()
  public protocol: BeaconDeviceProtocol;

  @OneToOne(() => File, { nullable: true })
  @JoinColumn()
  public file!: File;
}
